using System;
using UnityEditor;
using UnityEngine;

namespace Pancake.DailyRewardEditor
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
