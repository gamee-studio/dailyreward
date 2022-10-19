using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "DataDailyReward", menuName = "ScriptableObjects/DataDailyReward")]
public class DataDailyReward : ScriptableObject
{
    public List<RewardData> ListReward;

}
[Serializable]
public class RewardData
{
    public int Daynumber;
    public int Coinbonus;
    public int Skinnumber;
    public Sprite IconReward;


}
