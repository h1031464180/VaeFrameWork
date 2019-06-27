using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vae
{
    public class ManagerId
    {
        public const int msgSpan = 3000;
    }

    public enum ManagerID
    {
        None=-1,
        UIManager = ManagerId.msgSpan * 0,
        AssetManager = ManagerId.msgSpan * 1,
        SocketManager = ManagerId.msgSpan * 2,
        NetManager = ManagerId.msgSpan * 3,
        GameManager = ManagerId.msgSpan * 4,
    }
}