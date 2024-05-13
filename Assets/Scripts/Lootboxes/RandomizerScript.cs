using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    [Tooltip("Chansen att f� varje item, Alla v�rden tillsammans ska vara lika med 1")]
    public float[] rates;

    [Tooltip("Vilken tier varje entry i Rates motsvarar")]
    public string[] tiers;

    [Tooltip("Hur m�nga entries Dictionaryn ska ha")]
    public int entries = 10000;

    Dictionary<int, int> items = new Dictionary<int, int>(); //ID f�r varje entry och vilken plats ett visst item har i rates

    // Start is called before the first frame update
    void Start()
    {
        CreateItems(rates.Length, entries);

        /*for (int i = 0; i < entries; i++) //Skriver ut dictionaryn f�r debugging
        {
            print(items[i]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Tempor�r f�r testande
        {
            print("u got " + Randomize());
        }
    }

    public string Randomize() //V�ljer en slumpm�ssig variabel i items
    {
        int randomValue = Random.Range(0, entries); //V�ljer ett slumpm�ssigt v�rde mellan 0 och hur stor entries �r
        int x = items[randomValue]; //Sparar vilket entry randomValue motsvarar i items
        string text = tiers[x]; //Vilken tier x motsvarar 

        return text;
    }

    void CreateItems(int arrayLenght, int dictionaryLenght) //Skapar Item dictionaryn
    {
        int a = 0;
        int b = 0;
        for (int i = 0; i < arrayLenght; i++) //�ndrar vilket v�rde som sparas i items
        {
            for (int x = a; x < (rates[i] * dictionaryLenght + a); x++) //G�r igenom och l�gger till v�rden i items
            {
                items.Add(x, i);
                b = x;
            }
            a = b + 1; //Sparar vart i items funktionen �r
        }
        
    }
}
