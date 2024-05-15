using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineSteup : MonoBehaviour
{
    public Sprite[] images;
    public GameObject[,] slots;
    public int rowLength, rowSize;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
