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
            if (!EditorPrefs.GetBool($"__Example__{PlayerSettings.productGUID}", false))
            {
                ImportPackage.ImportExample();
                EditorPrefs.SetBool($"__Example__{PlayerSettings.productGUID}", true);
            }
        }
    }
}
