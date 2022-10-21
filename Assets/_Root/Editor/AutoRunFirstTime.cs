using System;
using UnityEditor;
using UnityEngine;

namespace Pancake.DailyReward
{
    [InitializeOnLoad]
    internal class AutoRunFirstTime
    {
        static AutoRunFirstTime()
        {
            Debug.Log("1");
            if (!EditorPrefs.GetBool($"__Example__{PlayerSettings.productGUID}", false))
            {
                Debug.Log("2");
                ImportPackage.ImportExample();
                EditorPrefs.SetBool($"__Example__{PlayerSettings.productGUID}", true);
            }
        }
    }
}
