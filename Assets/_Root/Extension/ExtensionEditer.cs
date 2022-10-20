using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class ExtensionEditer
{
    public static List<T> FindAllAssetComponents<T>() where T : Component
    {
        var gos = FindAllAssets<GameObject>();
        return gos.SelectMany(go => go.GetComponents<T>()).ToList();
    }
    public static List<T> FindAllAssets<T>() where T : Object
    {
        List<T> l = new List<T>();
#if UNITY_EDITOR
        var typeStr = typeof(T).ToString();
        typeStr = typeStr.Replace("UnityEngine.", "");

        if (typeof(T) == typeof(SceneAsset)) typeStr = "Scene";
        else if (typeof(T) == typeof(GameObject)) typeStr = "gameobject";

        var guids = AssetDatabase.FindAssets("t:" + typeStr);
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            T obj = AssetDatabase.LoadAssetAtPath<T>(path);
            if (obj != null) l.Add(obj);
        }
#else
            l.AddRange(Resources.FindObjectsOfTypeAll<T>());
#endif
        return l;
    }
}
