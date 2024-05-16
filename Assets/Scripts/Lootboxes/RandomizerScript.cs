using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizerScript : MonoBehaviour
{
    [Tooltip("Chansen att få varje tier, Alla värden tillsammans ska vara lika med värdet i tierEntries")]
    public int[] tierRates = new int[] { 5000, 3500, 1200, 299, 1 };

    [Tooltip("Vilken tier varje entry i Rates motsvarar")]
    public string[] tierNames = new string[] { "Common", "Uncommon", "Rare", "Epic", "legendary" };

    [Tooltip("Hur många entries dictionary för tiers ska ha")]
    public int tierEntries = 10000;
    [Space]

    [Tooltip("Antal items i varje tier")]
    public int[] itemsInTiers;

    Dictionary<int, int> tiersDictionary = new Dictionary<int, int>(); //Används för randomization av tiers

    // Start is called before the first frame update
    void Start()
    {
        CreateTiersDictionary(tierRates.Length);

        /*for (int i = 0; i < tierEntries; i++) //Skriver ut tiers för debugging
        {
            int x = tiersDictionary[i];
            string text = tierNames[x];
            print(text);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //Temporär för testande
        {
            Randomize();
        }
    }

    public void Randomize()
    {
        int randomValue = Random.Range(0, tierEntries); //Väljer ett slumpmässigt värde mellan 0 och hur stor tierEntries är
        int tierRepresentation = tiersDictionary[randomValue]; //Sparar vilket entry randomValue motsvarar för tier

        int item = Random.Range(0, itemsInTiers[tierRepresentation]); //Vilket item i motsvarande tier

        //AddItem funktion som lägger till det item spelaren fick

        string text = tierNames[tierRepresentation]; //Vilken tier tierRepresentation motsvarar
        print("U got " + text + " item " + item);
    }

    private void CreateTiersDictionary(int arrayLenght) //Skapar tierDictionary
    {
        int a = 0;
        int b = 0;

        for (int i = 0; i < arrayLenght; i++) //Ändrar vilket värde som sparas i tiersDictionary
        {
            for (int x = a; x < (tierRates[i] + a); x++) //Går igenom och lägger till värden i tiersDictionary
            {
                tiersDictionary.Add(x, i); //x motsvarar nyckel som går från 0 och upp, i motsvarar tier
                b = x;
            }
            a = b + 1; //Sparar vart i tiersDictionary funktionen är
        }
    }
}
