using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSlotMachine : MonoBehaviour
{
    [SerializeField] GameObject player;
    TempCurrency wallet;
    public GameObject[] row;
    bool[] spinning = {false,false,false};
    float timer = 0, timer1;
    public float spinSpeed;
    public float spinCost = 1;
    public float bet = 1;
    int[] betSizes = {1, 2, 3, 5, 10, 25, 50, 100};
    float[] chance = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1.5f, 1.5f, 1.5f, 1.5f, 2, 2, 10 };
    int betIndex;

    // Start is called before the first frame update
    void Start()
    {
        wallet = player.GetComponent<TempCurrency>();
        row = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            row[i] = transform.GetChild(i).gameObject;
        }
        UpdateBet(1);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (spinning[2] == true)
        {
            print("spinning");
            timer += Time.deltaTime;
            for (int i = 0; i < row.Length; i++)
            {
                if (spinning[i] == true)
                {
                    row[i].transform.position += new Vector3(0, -1, 0) * Time.deltaTime * spinSpeed;
                }
            }
        }
        if (timer > spinSpeed/600)
        {
            timer = 0;
            timer1++;
            print("reseting");
            for (int i = 0; i < row.Length; i++)
            {
                row[i].transform.position = new Vector3(row[i].transform.position.x,200);
            }
        }
        if (timer1 > 2)
        {
            spinning[0] = false;
        }
        if (timer1 > 4)
        {
            spinning[1] = false;
        }
        if (timer1 > 6)
        {
            spinning[2] = false;
        }

    }

    public void OnSpin()
    {
        if (spinning[2] == false)
        {
            
            if (wallet.TryPayMoney(spinCost))
            {
                timer = 0;
                for (int i = 0; i < spinning.Length; i++)
                {
                    spinning[i] = true;
                }
                print("clicked");
                wallet.EarnMoney(betSizes[betIndex] * chance[Random.Range(0, chance.Length - 1)]);
            }
        } 
    }
    public void OnBet()
    {
        betIndex += 1;
        if (betIndex == betSizes.Length)
        {
            betIndex = 0;
        }
        UpdateBet(betSizes[betIndex]);
    }

    public void UpdateBet(float newBet)
    {
        bet = newBet;
        spinCost = 1;
        spinCost *= bet;
    }
}
