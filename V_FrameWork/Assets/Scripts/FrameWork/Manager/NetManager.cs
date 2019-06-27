using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vae;

namespace Vae.Manager
{
    public class NetManager : ManagerBase
    {
        public static NetManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
            this.curManId = ManagerID.NetManager;
        }

    }
}