using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vae
{

    public class EventNode
    {
        //当前数据
        public MonoBase data;
        public EventNode next;

        public EventNode(MonoBase tmpData)
        {
            this.data = tmpData;
            this.next = null;
        }
    }

    public class ManagerBase : MonoBase
    {
        // 模块  ：  消息id  + 对应  mono树
        private Dictionary<ushort, EventNode> nodeTree = new Dictionary<ushort, EventNode>();
        public ManagerID curManId = ManagerID.None;

        public void SendMsg(MsgBase msg)
        {
            if (msg.GetManager() == curManId)
            {
                ProcessEvent(msg);
            }
            else
            {
                MsgCenter.Instance.SendToMsg(msg);
            }
        }

        //注册
        public void RegistMsg(MonoBase mono, params ushort[] msgs)
        {
            for (int i = 0; i < msgs.Length; i++)
            {
                EventNode tmpNode = new EventNode(mono);
                RegistMsg(msgs[i], tmpNode);
            }
        }

        public void RegistMsg(ushort id, EventNode node)
        {
            if (!nodeTree.ContainsKey(id))
            {
                nodeTree.Add(id, node);
            }
            else
            {   // 单个 id消息  往模块后面继续添加 --
                EventNode tmp = nodeTree[id];

                while (tmp.next != null)
                {   //找对最后一个节点添加
                    tmp = tmp.next;
                }
                tmp.next = node;
            }
        }


        public void UnRegistMsg(MonoBase mono, params ushort[] msgs)
        {
            for (int i = 0; i < msgs.Length; i++)
            {
                UnRegistMsg(msgs[i], mono);
            }
        }

        public void UnRegistMsg(ushort id, MonoBase mono)
        {
            if (!nodeTree.ContainsKey(id))
            {
                Debug.LogError("当前模块不包含该id：" + id);
                return;
            }
            else
            {
                EventNode tmp = nodeTree[id];
                if (tmp.data == mono)  //代表参数在首节点 data  
                {
                    EventNode header = tmp;
                    if (header.next != null)
                    {
                        nodeTree[id] = header.next;
                        header.next = null;
                    }
                    else
                    {
                        nodeTree.Remove(id);
                    }

                }
                else
                {
                    while (tmp.next != null && tmp.next.data != mono)
                    {
                        tmp = tmp.next;
                    }

                    if (tmp.next.next != null)
                    {
                        EventNode curNode = tmp.next;
                        tmp.next = curNode.next;
                        curNode = null;                             //类似 指针 将关联去掉 自动释放
                    }
                    else
                    {
                        tmp.next = null;
                    }

                }
            }

        }

        public override void ProcessEvent(MsgBase tmpMsg)
        {
            if (!nodeTree.ContainsKey(tmpMsg.msgId))
            {
                Debug.LogError("msg  不包含该 id：" + tmpMsg.msgId);
                Debug.LogError("msg 模块 为 s：" + tmpMsg.GetManager());
                return;
            }
            else
            {
                EventNode tmpNoe = nodeTree[tmpMsg.msgId];
                while (tmpNoe != null)
                {
                    if (tmpNoe.data.isActiveAndEnabled)
                    {
                        tmpNoe.data.ProcessEvent(tmpMsg);
                    }
                    tmpNoe = tmpNoe.next;
                }
            }
        }
    }
}