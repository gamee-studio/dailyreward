using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailyRewardItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtDay;
    public void Init(int Index)
    {
        txtDay.text = "Day " + Index.ToString();
    }
}
