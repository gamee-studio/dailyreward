using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pancake.DailyReward
{
    public class DailyRewardItem : MonoBehaviour
    {
        private int Index;
        [SerializeField] TextMeshProUGUI txtDay;
        [SerializeField] TextMeshProUGUI txtValue;
        [SerializeField] private Image img;
        [SerializeField] private Image DoneIcon;
        [SerializeField] private GameObject BGDay;
        [SerializeField] private GameObject BGActive;
        private DataDailyReward DataDaily;


        public void Init(DataDailyReward DataDaily, int Index)
        {
            this.DataDaily = DataDaily;
            this.Index = Index;
            txtDay.text = "Day " + Index.ToString();
            txtValue.text = DataDaily.ListReward[Index - 1].Coinbonus.ToString();
            img.sprite = DataDaily.ListReward[Index - 1].IconReward;
            img.SetNativeSize();
            Reset();
        }
        private void ChangeDayName()
        {
            txtDay.text = "Day " + ((Data.WeekReal - 1) * DataDaily.ListReward.Count + Index).ToString();

        }
        public void Reset()
        {
            if (Index == Data.TotalDays + 1 && !Data.isClaimed)
            {
                DoneIcon.gameObject.SetActive(false);
                BGActive.gameObject.SetActive(true);
            }
            else if (Index == Data.TotalDays + 1 && Data.isClaimed)
            {
                BGActive.gameObject.SetActive(false);
                DoneIcon.gameObject.SetActive(true);
            }
            else if (Index < Data.TotalDays + 1)
            {
                DoneIcon.gameObject.SetActive(true);
            }
            else
            {
                DoneIcon.gameObject.SetActive(false);
            }
            ChangeDayName();

        }



    }
}
