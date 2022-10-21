using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeShowNextRw : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Time;
    [SerializeField] private DailyRewardPopup dailyRewardPopup;
    void Update()
    {
        if (Utils.CanChangeTotalDay == 0)
        {
            Time.text = "00:00:00";
        }
        else
        {
            Time.text = Utils.SecondsToTimeFormatBeforeNewDay().ToString();
            if (Utils.SecondsToTimeFormatBeforeNewDay().ToString() == "00:00:00")
            {
                dailyRewardPopup.CheckUpdateDayDaily();
            }
        }
    }
}
