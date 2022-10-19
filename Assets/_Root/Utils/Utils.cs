using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static void Clear(this Transform transform)
    {
        var childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject, true);
        }
    }
}
