using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pachinko : MonoBehaviour
{
    int dropAmount;
    public int money = 500;
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
            dropAmount += 5;
            if(dropAmount > 30)
            {
                dropAmount = 30;
            }
            amountText.text = "ball count: " + dropAmount;
        }
    }

    public void decrease()
    {
        dropAmount -= 5;
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
            Invoke("resetDrop", dropAmount / 1.5f);
            for (int i = 0; i < currentBalls.Count; i++)
            {
                Destroy(currentBalls[i]);
                currentBalls.Clear();
            }

            for (float i = 0; i < dropAmount; i++)
            {
                Invoke("SpawnObject", i / 1.5f);
                money -= 5;
            }
        }
    }

    void SpawnObject()
    {
        int chooseSpawn = Random.Range(0, spawnPos.Count);
        GameObject newest = Instantiate(ball, spawnPos[3], Quaternion.identity);
        currentBalls.Add(newest);
        newest.GetComponent<Rigidbody>().AddForce(Random.Range(-5, 6), 0, 0);
    }

    void resetDrop()
    {
        canDrop = true;
    }
}
