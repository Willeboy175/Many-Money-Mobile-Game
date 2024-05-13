using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pachinko : MonoBehaviour
{
    int dropAmount;
    int money = 500;
    public GameObject ball;
    public Vector3 spawnPos;

    public TextMeshProUGUI amountText;
    public TextMeshProUGUI moneyText;

    void Start()
    {

    }

    void Update()
    {
        moneyText.text = "money: " + money;
    }

    public void increase()
    {
        if(dropAmount * 5 < money)
        {
            dropAmount += 1;
            if(dropAmount > 15)
            {
                dropAmount = 15;
            }
            amountText.text = "ball count: " + dropAmount;
        }
    }

    public void decrease()
    {
        dropAmount -= 1;
        if (dropAmount < 1)
        {
            dropAmount = 1;
        }
        amountText.text = "ball count: " + dropAmount;
    }

    public void dropThings()
    {
        for (int i = 0; i < dropAmount; i++)
        {
            Invoke("SpawnObject", i);
            money -= 5;
        }
    }

    void SpawnObject()
    {
        GameObject newest = Instantiate(ball, spawnPos, Quaternion.identity);
        newest.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1), 0, 0);
    }
}
