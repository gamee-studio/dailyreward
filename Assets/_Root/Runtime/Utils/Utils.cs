using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pancake.DailyReward
{
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
            bool time = (DateTime.Now - DateTime.Parse(Data.DateTimeCheck)).TotalSeconds >= 1 * 60 * 60 * 24;
            if (time)
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
            // time end day
            DateTime now = DateTime.Now;
            DateTime end = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
            var x1 = end - now;

            // time to next
            DateTime check = new DateTime(DateTime.Parse(Data.DateTimeCheck).Year, DateTime.Parse(Data.DateTimeCheck).Month, DateTime.Parse(Data.DateTimeCheck).Day, DateTime.Parse(Data.DateTimeCheck).Hour, DateTime.Parse(Data.DateTimeCheck).Minute, DateTime.Parse(Data.DateTimeCheck).Second);
            DateTime check2 = check.AddDays(1);
            DateTime end2 = check.AddDays(1).AddHours(DateTime.Parse(Data.DateTimeCheck).Hour).AddMinutes(DateTime.Parse(Data.DateTimeCheck).Minute).AddSeconds(DateTime.Parse(Data.DateTimeCheck).Second);
            var x2 = end2 - check2;

            return x1 + x2;


        }
        public static int CanChangeTotalDay { get => PlayerPrefs.GetInt(Constants.CAN_CHANGE_TOTAL_DAY, 0); set => PlayerPrefs.SetInt(Constants.CAN_CHANGE_TOTAL_DAY, value); }
    }
}




