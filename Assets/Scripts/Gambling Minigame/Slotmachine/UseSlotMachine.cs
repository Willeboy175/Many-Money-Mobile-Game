using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseSlotMachine : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI betTXT, walletTXT;
    [SerializeField] LittleWiggle holder;
    public TempCurrency wallet;    
    public GameObject[,] slots;
    public GameObject[] row;

    bool[] spinning = {false,false,false};
    float timer = 0, timer1;

    public float spinSpeed;
    public float spinWait;
    public float spinCost = 1;

    public float bet = 1;
    int betIndex;
    int[] betSizes = {1, 2, 3, 5, 10, 25, 50, 100};
   
   


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
            timer += Time.deltaTime;
            for (int i = 0; i < row.Length; i++)
            {
                if (spinning[i] == true)
                {
                    row[i].transform.position += new Vector3(0, -1, 0) * Time.deltaTime * spinSpeed;
                }
            }
            holder.wiggle = true;
            
        }
        if (timer > spinSpeed/500)
        {
            timer = 0;
            timer1++;
            for (int i = 0; i < row.Length; i++)
            {
                row[i].transform.position = new Vector3(row[i].transform.position.x,200);
            }
        }
        if (timer1 > 1 * spinWait)
        {
            spinning[0] = false;
        }
        if (timer1 > 2 * spinWait)
        {
            spinning[1] = false;
        }
        if (timer1 > 3 * spinWait)
        {
            spinning[2] = false;
        }
        if (timer1 > 3 * spinWait + spinWait/4)
        {
            wallet.EarnMoney((betSizes[betIndex] * GetComponent<SlotMachineSteup>().CheckWinValueLine(5)));
            ResetSlotMachine();
        }

    }

    public void OnSpin()
    {
        if (spinning[2] == false)
        {
            if (wallet.TryPayMoney(spinCost))
            {
                ResetSlotMachine();
                for (int i = 0; i < spinning.Length; i++)
                {
                    spinning[i] = true;
                    GetComponent<SlotMachineSteup>().RerollRowImage(i);
                }
                print("clicked");
                //wallet.EarnMoney(betSizes[betIndex] * chance[Random.Range(0, chance.Length - 1)]); -temporary 
                
                
            }
        } 
    }
    public void OnBet()
    {
        if (spinning[2] == false)//can only bet when slotmachine not spinning
        {
            betIndex += 1;
            if (betIndex == betSizes.Length)
            {
                betIndex = 0;
            }
            UpdateBet(betSizes[betIndex]);

        }
        
    }

    public void UpdateBet(float newBet)
    {
        bet = newBet;
        spinCost = 1;
        spinCost *= bet;
        betTXT.text = ("x"+betSizes[betIndex]);
    }

    public void ResetSlotMachine()
    {
        timer = 0;
        timer1 = 0;
        holder.wiggle = false;


    }
}
