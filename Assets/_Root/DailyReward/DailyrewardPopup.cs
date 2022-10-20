using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DailyrewardPopup : MonoBehaviour
{
    public List<DailyRewardItem> ListDay;
    public DataDailyReward dataReward;
    public RowDailyreward Row;
    [SerializeField] private Transform content;


    private void Awake()
    {
        dataReward = DataDailyReward.Current;
        // quantity of reward will alway is a number%7=0
        var week = (int)(dataReward.ListReward.Count / 7);
        content.Clear();
        int index = 0;
        while (index < (int)((dataReward.ListReward.Count - week) / 3) + week)
        {
            RowDailyreward row = Instantiate(Row, content);
            row.Init(dataReward, index, 3, this);
            index++;
        }


    }
    public void OnClaimReward()
    {
        if (Data.isClaimed) return;
        Data.DateTimeCheck = DateTime.Now.ToString();
        try
        {
            Data.CoinTotal += dataReward.ListReward[Data.TotalDays].Coinbonus;
        }
        catch
        {
            Debug.Log(Data.TotalDays);
        }

        Utils.CanChangeTotalDay = 1;
        Data.isClaimed = true;
        ResetItem();

    }

    public void OnClickPlusDay()
    {
        // this function is debug in this popup to change time by  the way "Minus 1 day value of DateTimeCheck" 
        Data.DateTimeCheck = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1, 00, 00, 00).ToString();
        if (Utils.CanChangeTotalDay == 1)
        {
            Data.SetTotalDays();
            Data.isClaimed = false;
            ResetLoopReward();
            ResetItem();

        }
    }
    public void ResetItem()
    {
        if (ListDay.Count == 0) return;
        foreach (var x in ListDay)
        {
            x.Reset();
        }
    }
    private void ResetLoopReward()
    {
        Debug.Log(Data.TotalDays);
        if (Data.TotalDays == ListDay.Count)
        {
            Data.TotalDays = 0;
        }
    }



}
