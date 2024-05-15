using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    [Tooltip("Chansen att f� varje tier, Alla v�rden tillsammans ska vara lika med v�rdet i tierEntries")]
    public int[] tierRates = new int[] { 5000, 3500, 1200, 299, 1 };

    [Tooltip("Vilken tier varje entry i Rates motsvarar")]
    public string[] tierNames = new string[] { "Common", "Uncommon", "Rare", "Epic", "legendary" };

    [Tooltip("Hur m�nga entries dictionary f�r tiers ska ha")]
    public int tierEntries = 10000;
    [Space]

    [Tooltip("Antal items i varje tier")]
    public int[] itemsInTiers;

    Dictionary<int, int> tiersDictionary = new Dictionary<int, int>(); //Anv�nds f�r randomization av tiers

    // Start is called before the first frame update
    void Start()
    {
        CreateTiersDictionary(tierRates.Length);

        /*for (int i = 0; i < tierEntries; i++) //Skriver ut tiers f�r debugging
        {
            int x = tiersDictionary[i];
            string text = tierNames[x];
            print(text);
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

    public void Randomize()
    {
        int randomValue = Random.Range(0, tierEntries); //V�ljer ett slumpm�ssigt v�rde mellan 0 och hur stor tierEntries �r
        int tierRepresentation = tiersDictionary[randomValue]; //Sparar vilket entry randomValue motsvarar f�r tier

        int item = Random.Range(0, itemsInTiers[tierRepresentation]); //Vilket item i motsvarande tier

        //AddItem funktion som l�gger till det item spelaren fick

        string text = tierNames[tierRepresentation]; //Vilken tier tierRepresentation motsvarar
        print("U got " + text + " item " + item);
    }

    private void CreateTiersDictionary(int arrayLenght) //Skapar tierDictionary
    {
        int a = 0;
        int b = 0;

        for (int i = 0; i < arrayLenght; i++) //�ndrar vilket v�rde som sparas i tiersDictionary
        {
            for (int x = a; x < (tierRates[i] + a); x++) //G�r igenom och l�gger till v�rden i tiersDictionary
            {
                tiersDictionary.Add(x, i); //x motsvarar nyckel som g�r fr�n 0 och upp, i motsvarar tier
                b = x;
            }
            a = b + 1; //Sparar vart i tiersDictionary funktionen �r
        }
    }
}
