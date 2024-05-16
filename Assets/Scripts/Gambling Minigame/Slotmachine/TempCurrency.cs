using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCurrency : MonoBehaviour
{
    public float currency;

    public void EarnMoney(float gain)
    {
        print(gain);
        currency += gain;
    }
    public void LoseMoney(float gain)
    {
        if (currency - gain > -1)
        {
            currency -= gain;
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
}
