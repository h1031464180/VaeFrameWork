using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vae
{

    public class MsgBase
    {
        public ushort msgId;

        public ManagerID GetManager()
        {
            int tmpId = msgId / ManagerId.msgSpan;
            return (ManagerID)(tmpId * ManagerId.msgSpan);
        }

        public MsgBase(ushort tmpId)
        {
            msgId = tmpId;
        }

    }


}