using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardItem : MonoBehaviour
{
    private int Index;
    [SerializeField] TextMeshProUGUI txtDay;
    [SerializeField] TextMeshProUGUI txtValue;
    [SerializeField] private Image img;
    [SerializeField] private Image DoneIcon;
    [SerializeField] private GameObject BGDay;
    [SerializeField] private GameObject BGActive;


    public void Init(DataDailyReward Data, int Index)
    {
        this.Index = Index;
        txtDay.text = "Day " + Index.ToString();
        txtValue.text = Data.ListReward[Index - 1].Coinbonus.ToString();
        img.sprite = Data.ListReward[Index - 1].IconReward;
        img.SetNativeSize();
        Reset();
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

    }



}
