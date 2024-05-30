using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineSteup : MonoBehaviour
{
    public Sprite[] images;
    public GameObject[,] slots;
    public int rowLength, rowSize;
    int winIndex;

    void Start()
    {
        rowLength = transform.childCount;
        rowSize = transform.GetChild(0).childCount;
        slots = new GameObject[rowLength, rowSize];
        for (int i = 0; i < slots.Length/rowSize; i++)
        {
            for (int ii = 0; ii < slots.Length/rowLength; ii++)
            {
                slots[i, ii] = transform.GetChild(i).GetChild(ii).gameObject;
                slots[i, ii].GetComponent<Image>().sprite = images[Random.Range(0,images.Length-1)];
                slots[i, ii].transform.position += new Vector3(0, ii * 200);
                print(slots[i, ii].name);
            }
        }
        int img = images.Length;
        
    }

    public int CheckWinValueLine(int line)
    {
        string[] id = new string[rowLength];
        for (int i = 0; i < rowLength; i++)
        {
            id[i] = slots[i, line].GetComponent<Image>().sprite.name;
        }
        for (int i = 0; i < rowLength; i++)
        {
            if (slots[0, line].GetComponent<Image>().sprite.name == id[i])
            {
                print("SAME");
                winIndex += 1;
            }
            if (slots[1, line].GetComponent<Image>().sprite.name == id[i])
            {
                print("SAME");
                winIndex += 1;
            }
            if (slots[2, line].GetComponent<Image>().sprite.name == id[i])
            {
                print("SAME");
                winIndex += 1;
            }
        }
        
        if (winIndex > 4)
        {
            winIndex = 2; //win 2x on two the on same icon
            if (winIndex > 5)
            {
                winIndex = 10; //win 10x on all the on same icon
            }
        }
        else
        {
            winIndex = 0; //otherwise no win
        }
        return winIndex;
    }
    public void RerollRowImage(int row)
    {
        for (int i = 0; i < slots.Length / rowLength; i++)
        {
            slots[row, i].GetComponent<Image>().sprite = images[Random.Range(0, images.Length - 1)];
        }
    }
}
