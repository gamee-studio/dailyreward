using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

// [CreateAssetMenu(fileName = "DataDailyReward", menuName = "ScriptableObjects/DataDailyReward")]
public class DataDailyReward : ScriptableObject
{
    private const string EDITOR_BUILD_SETTINGS_GUID = "Editor Settings Asset";
    public List<RewardData> ListReward;
    // Create DataDailyReward if Null
#if UNITY_EDITOR
    public static DataDailyReward Current
    {
        get
        {
            if (!EditorBuildSettings.TryGetConfigObject<DataDailyReward>(EDITOR_BUILD_SETTINGS_GUID, out DataDailyReward settings))
            {
                settings = ExtensionEditer.FindAllAssets<DataDailyReward>().FirstOrDefault(a => a != null) as DataDailyReward;

                if (settings == null)
                {
                    settings = CreateInstance<DataDailyReward>();
                    var editorResourcePath = "Assets/_Root/DailyResources/";
                    if (!editorResourcePath.DirectoryExists()) editorResourcePath.CreateDirectory();
                    string path = AssetDatabase.GenerateUniqueAssetPath("Assets/_Root/DailyResources/DataDailyReward.asset");
                    AssetDatabase.CreateAsset(settings, path);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }

                EditorBuildSettings.AddConfigObject(EDITOR_BUILD_SETTINGS_GUID, settings, true);
            }

            return settings;
        }
    }
#endif


}
[Serializable]
public class RewardData
{
    public int Daynumber;
    public int Coinbonus;
    public int Skinnumber;
    public Sprite IconReward;


}
