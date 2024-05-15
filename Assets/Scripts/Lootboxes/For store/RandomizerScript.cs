using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    [Tooltip("Chansen att f� varje item, Alla v�rden tillsammans ska vara lika med 1")]
    public float[] tierRates;

    [Tooltip("Vilken tier varje entry i Rates motsvarar")]
    public string[] tierNames;

    [Tooltip("Hur m�nga entries Dictionaryn ska ha")]
    public int tierEntries = 10000;

    public int itemsPerTier = 10;

    Dictionary<int, int> tiers = new Dictionary<int, int>(); //ID f�r varje entry och vilken plats ett visst item har i rates

    // Start is called before the first frame update
    void Start()
    {
        CreateTiers(tierRates.Length, tierEntries);

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
            Randomize();
        }
    }

    public void Randomize() //V�ljer en slumpm�ssig variabel i items
    {
        int randomValue = Random.Range(0, tierEntries); //V�ljer ett slumpm�ssigt v�rde mellan 0 och hur stor entries �r
        int x = tiers[randomValue]; //Sparar vilket entry randomValue motsvarar i items
        string text = tierNames[x]; //Vilken tier x motsvarar

        int item = Random.Range(0, itemsPerTier);

        print("U got " + text + " item " + item);
    }

    void CreateTiers(int arrayLenght, int dictionaryLenght) //Skapar Item dictionaryn
    {
        int a = 0;
        int b = 0;
        for (int i = 0; i < arrayLenght; i++) //�ndrar vilket v�rde som sparas i items
        {
            for (int x = a; x < (tierRates[i] * dictionaryLenght + a); x++) //G�r igenom och l�gger till v�rden i items
            {
                tiers.Add(x, i);
                b = x;
            }
            a = b + 1; //Sparar vart i items funktionen �r
        }
        
    }
}
