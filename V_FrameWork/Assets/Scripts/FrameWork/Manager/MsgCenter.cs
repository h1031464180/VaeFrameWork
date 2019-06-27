using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vae.Manager;

namespace Vae
{
    public class MsgCenter : MonoBehaviour
    {
        public static MsgCenter Instance;
        private void Awake()
        {
            Instance = this;

            //从下 加载模块s
            this.gameObject.GetOrCreateComponent<UIManager>();
        }

        public void SendToMsg(MsgBase tmpMsg)
        {
            AnasysisMsg(tmpMsg);
        }

        private void AnasysisMsg(MsgBase tmpMsg)
        {
            ManagerID tmpId = tmpMsg.GetManager();
            switch (tmpId)
            {
                case ManagerID.UIManager:
                    UIManager.Instance.SendMsg(tmpMsg);
                    //GameManager.Instance.SendMssg(tmpMsg);
                    break;
            }


        }

    }
}