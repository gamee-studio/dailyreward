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

                Check();
            }
        }
        private static void Check()
        {
            var editorResourcePath = "Assets/ExampleScene/";
            if (!editorResourcePath.DirectoryExists())
            {
                Debug.Log("you dont have that folder");
            }
            else
            {
                Debug.Log("done import");
                EditorPrefs.SetBool($"__Example__{PlayerSettings.productGUID}", true);
            }

        }
    }

}
