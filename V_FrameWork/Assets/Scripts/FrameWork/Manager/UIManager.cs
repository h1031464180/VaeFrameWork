using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vae;
namespace Vae.Manager
{
    public class UIManager : ManagerBase
    {
        public static UIManager Instance { private set; get; }


        //规定了开发方式 ， 消耗内存 ， 换取速度 和方便
        private Dictionary<string, GameObject> sonMembers = new Dictionary<string, GameObject>();

        private void Awake()
        {
            Instance = this;
            this.curManId = ManagerID.UIManager;
        }

        #region 拓展

        public void RegistGameObject(string name, GameObject obj)
        {
            if (!sonMembers.ContainsKey(name))
            {
                sonMembers.Add(name, obj);
            }
            else
            {
                Debug.LogError("same name of the unit! the name is:" + name);
            }
        }

        public void UnRegistGameObject(string name)
        {
            if (sonMembers.ContainsKey(name))
            {
                sonMembers.Remove(name);
            }
        }


        public GameObject GetGameObject(string name)
        {
            if (sonMembers.ContainsKey(name))
            {
                return sonMembers[name];
            }
            return null;
        }

        public GameObject ShowUI(string tmpName)
        {
            var uiGo = GetGameObject(tmpName);
            if (uiGo)
            {
                uiGo.SetActive(true);
                return uiGo;
            }
            return null;
        }


        public void SetUIShowOrHide(string tmpName, bool isShow)
        {
            var uiGo = GetGameObject(tmpName);
            uiGo.SetActive(isShow);
        }

        #endregion

    }
}