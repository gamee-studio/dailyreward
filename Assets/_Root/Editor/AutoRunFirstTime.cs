using System;
using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
internal class AutoRunFirstTime
{
    private static readonly string[] NameFiles = { "AssetContainer.asset" };
    private static int internalIndex = 0;
    static AutoRunFirstTime()
    {
        if (!EditorPrefs.GetBool($"__firsttime__{PlayerSettings.productGUID}", false))
        {
            ImportPackage.ImportExample();
        }
    }
}
