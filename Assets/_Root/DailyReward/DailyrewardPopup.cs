using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyrewardPopup : MonoBehaviour
{
    public List<DailyRewardItem> ListDay;
    public List<RowDailyreward> ListRow;
    public DataDailyReward DataReward;
    public RowDailyreward Row;
    [SerializeField] private Transform content;
    public bool ScrollviewStype = true;
    [SerializeField] private ScrollRect scrollrect;


    private void Awake()
    {
        DataReward = DataDailyReward.Current;
        // quantity of reward will alway is a number%7=0
        var week = (int)(DataReward.ListReward.Count / 7);
        content.Clear();
        if (!ScrollviewStype)
        {
            var scrollbar = scrollrect.verticalScrollbar;
            scrollrect.verticalScrollbar = null;
            scrollbar.gameObject.SetActive(false);
            scrollrect.vertical = false;

        }

        int index = 0;
        while (index < (int)((DataReward.ListReward.Count - week) / 3) + week)
        {
            RowDailyreward row = Instantiate(Row, content);
            ListRow.Add(row);
            row.Init(DataReward, index, 3, this);
            index++;
        }
        HideWeekClaimed();

    }

    public void OnClaimReward()
    {
        if (Data.isClaimed) return;
        Data.DateTimeCheck = DateTime.Now.ToString();
        try
        {
            Data.CoinTotal += DataReward.ListReward[Data.TotalDays].Coinbonus;
        }
        catch
        {
            // Debug.Log(Data.TotalDays);
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

        var week = (int)(DataReward.ListReward.Count / 7);
        if (((Data.TotalDays) % 7 == 0) && !ScrollviewStype)
        {
            Data.WeekCurrent++;

            if (week == Data.WeekCurrent + 1) return;
            HideWeekClaimed();
        }
        if (Data.TotalDays == ListDay.Count)
        {
            Data.TotalDays = 0;
            Data.WeekCurrent = 1;
            foreach (var x in ListRow)
            {
                x.gameObject.SetActive(true);
            }
        }
    }
    private void HideWeekClaimed()
    {
        for (int i = 0; i < Data.WeekCurrent - 1; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                ListRow[j].gameObject.SetActive(false);

            }
        }
    }




}
