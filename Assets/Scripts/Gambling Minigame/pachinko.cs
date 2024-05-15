using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pachinko : MonoBehaviour
{
    int dropAmount;
    int money = 500;
    public GameObject ball;
    public List<Vector3> spawnPos = new List<Vector3>();
    List<GameObject> currentBalls = new List<GameObject>();
    bool canDrop = true;

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
        if(canDrop && dropAmount * 5 < money)
        {
            canDrop = false;
            Invoke("resetDrop", dropAmount);
            for (int i = 0; i < currentBalls.Count; i++)
            {
                Destroy(currentBalls[i]);
                currentBalls.Clear();
            }

            for (int i = 0; i < dropAmount; i++)
            {
                Invoke("SpawnObject", i);
                money -= 5;
            }
        }
    }

    void SpawnObject()
    {
        int chooseSpawn = Random.Range(0, 4);
        GameObject newest = Instantiate(ball, spawnPos[chooseSpawn], Quaternion.identity);
        currentBalls.Add(newest);
    }

    void resetDrop()
    {
        canDrop = true;
    }
}
