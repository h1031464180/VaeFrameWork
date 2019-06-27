using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    /// <summary>
    /// 获取或添加控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tmpGo"></param>
    /// <param name="tmpComp"></param>
    /// <returns></returns>
    public static T GetOrCreateComponent<T>(this GameObject tmpGo) where T : Component
    {
        T comp = tmpGo.GetComponent<T>();
        return comp ? comp : tmpGo.AddComponent<T>();
    }

    /// <summary>
    /// 删除所有子物体
    /// </summary>
    /// <param name="tmpObj"></param>
    public static void DeleteAllChild(this GameObject tmpObj)
    {
        for (int i = 0; i < tmpObj.transform.childCount - 1; i++)
        {
            UnityEngine.Object.Destroy(tmpObj.transform.GetChild(i).gameObject);
        }
    }
}
