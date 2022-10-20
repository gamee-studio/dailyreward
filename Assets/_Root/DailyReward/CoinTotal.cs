using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinTotal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinTotal;
    private void Awake()
    {
        EventController.CoinTotalChanged += UpdateCoinText;

        UpdateCoinText();
    }

    public void UpdateCoinText()
    {

        if (coinTotal != null && coinTotal.gameObject.activeSelf)
        {
            coinTotal.text = Data.CoinTotal.ToString();


        }

    }
}
