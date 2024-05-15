using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    [Tooltip("Chansen att få varje item, Alla värden tillsammans ska vara lika med 1")]
    public float[] rates;

    [Tooltip("Vilken tier varje entry i Rates motsvarar")]
    public string[] tiers;

    [Tooltip("Hur många entries Dictionaryn ska ha")]
    public int entries = 10000;

    Dictionary<int, int> items = new Dictionary<int, int>(); //ID för varje entry och vilken plats ett visst item har i rates

    // Start is called before the first frame update
    void Start()
    {
        CreateItems(rates.Length, entries);

        /*for (int i = 0; i < entries; i++) //Skriver ut dictionaryn för debugging
        {
            print(items[i]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Temporär för testande
        {
            print("u got " + Randomize());
        }
    }

    public string Randomize() //Väljer en slumpmässig variabel i items
    {
        int randomValue = Random.Range(0, entries); //Väljer ett slumpmässigt värde mellan 0 och hur stor entries är
        int x = items[randomValue]; //Sparar vilket entry randomValue motsvarar i items
        string text = tiers[x]; //Vilken tier x motsvarar 

        return text;
    }

    void CreateItems(int arrayLenght, int dictionaryLenght) //Skapar Item dictionaryn
    {
        int a = 0;
        int b = 0;
        for (int i = 0; i < arrayLenght; i++) //Ändrar vilket värde som sparas i items
        {
            for (int x = a; x < (rates[i] * dictionaryLenght + a); x++) //Går igenom och lägger till värden i items
            {
                items.Add(x, i);
                b = x;
            }
            a = b + 1; //Sparar vart i items funktionen är
        }
        
    }
}
