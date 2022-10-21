using System;
using UnityEditor;
using UnityEngine;


[InitializeOnLoad]
internal class AutoRunFirstTime
{
    static AutoRunFirstTime()
    {
        if (!EditorPrefs.GetBool($"__Example__{PlayerSettings.productGUID}", false))
        {
            ImportPackage.ImportExample();
        }
    }
}
