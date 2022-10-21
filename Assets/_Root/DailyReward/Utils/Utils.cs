using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    public static void Clear(this Transform transform)
    {
        var childs = transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject, true);
        }
    }
    public static string SecondsToTimeFormatBeforeNewDay()
    {
        var time = DateTime.Now.Day - DateTime.Parse(Data.DateTimeCheck).Day;
        if (time >= 1)
        {
            return "00:00:00";
        }
        else
        {
            TimeSpan distance = TimeBeforeNewDay();

            return string.Format("{0:00}:{1:00}:{2:00}", distance.Hours, distance.Minutes, distance.Seconds);
        }
    }
    public static TimeSpan TimeBeforeNewDay()
    {
        DateTime now = DateTime.Now;
        DateTime end = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);


        DateTime check = new DateTime(DateTime.Parse(Data.DateTimeCheck).Year, DateTime.Parse(Data.DateTimeCheck).Month, DateTime.Parse(Data.DateTimeCheck).Day, DateTime.Parse(Data.DateTimeCheck).Hour, DateTime.Parse(Data.DateTimeCheck).Minute, DateTime.Parse(Data.DateTimeCheck).Second);

        DateTime check2 = new DateTime(check.Year, check.Month, check.Day + 1, 00, 00, 00);
        DateTime end2 = new DateTime(check.Year, check.Month, check.Day + 1, DateTime.Parse(Data.DateTimeCheck).Hour, DateTime.Parse(Data.DateTimeCheck).Minute, DateTime.Parse(Data.DateTimeCheck).Second);
        var x1 = end - now;
        // time end day
        var x2 = end2 - check2;
        // time to next
        return x1 + x2;


    }
    public static int CanChangeTotalDay { get => PlayerPrefs.GetInt(Constants.CAN_CHANGE_TOTAL_DAY, 0); set => PlayerPrefs.SetInt(Constants.CAN_CHANGE_TOTAL_DAY, value); }
}




