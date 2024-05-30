using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempCurrency : MonoBehaviour
{
    public float currency;
    TextMeshProUGUI displayCurrency;

    private void Start()
    {
        displayCurrency = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public void EarnMoney(float gain)
    {
        print("you got "+gain);
        currency += gain;
        UpdateDisplay();
    }
    public void LoseMoney(float gain)
    {
        if (currency - gain > -1)
        {
            currency -= gain;
            UpdateDisplay();
        }
        
    }
    public bool TryPayMoney(float pay)
    {
        if (pay <= currency)
        {
            LoseMoney(pay);
            return true;
        }
        return false;
    }

    public void UpdateDisplay()
    {
        displayCurrency.text = "" + currency;
    }
}
