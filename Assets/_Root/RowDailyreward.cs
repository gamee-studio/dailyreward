using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowDailyreward : MonoBehaviour
{
    public DailyRewardItem DayItem;
    public DailyRewardItem DayItem7;
    public void Init(DataDailyReward Data, int Index, int ChildItem)
    {
        if ((Index + 1) % 3 != 0)
        {
            for (int i = 0; i < ChildItem; i++)
            {
                DailyRewardItem Dayitem = Instantiate(DayItem, this.transform);
                var weeknumber = (int)(Index / 3);
                Dayitem.Init((Index - weeknumber) * 3 + (i + 1 + weeknumber));
            }
        }
        else
        {
            DailyRewardItem Dayitem = Instantiate(DayItem7, this.transform);
        }
    }
}
