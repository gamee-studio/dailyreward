using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DailyrewardPopup : MonoBehaviour
{
    public List<DailyRewardItem> ListDay;
    public DataDailyReward data;
    public RowDailyreward Row;
    [SerializeField] private Transform content;

    private void Awake()
    {
        // quantity of reward will alway is a number%7=0
        var week = (int)(data.ListReward.Count / 7);
        content.Clear();
        int index = 0;
        while (index < (int)((data.ListReward.Count - week) / 3) + week)
        {
            RowDailyreward row = Instantiate(Row, content);
            row.Init(data, index, 3);
            index++;
        }
    }



}
