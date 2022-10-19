using System;
using UnityEngine;

public static class Data
{

    public static int CoinTotal
    {
        get => GetInt(Constants.COIN_TOTAL, 0);
        set
        {
            SetInt(Constants.COIN_TOTAL, value);
            EventController.CoinTotalChanged();
        }
    }
    public static int TotalDays
    {
        get => GetInt(Constants.TOTALDAYS, 0);
        set
        {
            SetInt(Constants.TOTALDAYS, value);
        }
    }
    public static void SetTotalDays()
    {
        var time = DateTime.Now.Day - DateTime.Parse(DateTimeCheck).Day;
        if (time >= 1)
        {
            TotalDays += 1;
            Utils.CanChangeTotalDay = 0;
        }
        else
        {
            return;
        }
    }
    private static int GetInt(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
    private static void SetInt(string id, int value) => PlayerPrefs.SetInt(id, value);
    public static string GetString(string key, string defaultValue) => PlayerPrefs.GetString(key, defaultValue);
    public static void SetString(string id, string value) => PlayerPrefs.SetString(id, value);
    private static void SetBool(string id, bool value) => PlayerPrefs.SetInt(id, value ? 1 : 0);
    private static bool GetBool(string key, bool defaultValue = false) => PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) > 0;
    public static string DateTimeCheck { get => GetString(Constants.DATE_TIME_CHECK, ""); set => SetString(Constants.DATE_TIME_CHECK, value); }
    public static bool isClaimed { get => GetBool(Constants.IS_CLAIMED_REWARD, false); set => SetBool(Constants.IS_CLAIMED_REWARD, value); }
}
