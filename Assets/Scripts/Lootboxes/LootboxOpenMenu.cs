using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootboxOpenMenu : MonoBehaviour
{
    public float delay = 3f;

    public TextMeshProUGUI tierText;
    public TextMeshProUGUI itemText;

    public Color32[] tierColors = new Color32[] { new Color32(0, 255, 0, 255), new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255), 
                                                  new Color32(0, 0, 0, 255), new Color32(0, 0, 0, 255) };


    [Tooltip("Vilken tier varje entry i Rates motsvarar")]
    public string[] tierNames = new string[] { "Common", "Uncommon", "Rare", "Epic", "legendary" };


    private int tier;
    private int item;

    private RandomizerScript randomScript;

    // Start is called before the first frame update
    void Start()
    {
        randomScript = GetComponent<RandomizerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenLootbox()
    {
        //Trigger animation

        //Tar fram tier och vilket item i den tieren
        tier = randomScript.RandomizeTier();
        item = randomScript.RandomizeItem(tier);

        //AddItem funktion 

        //Delay innan texten visas + visa tier sen item

        //Ändrar texten till respektive tier och item
        tierText.text = tierNames[tier];
        itemText.text = item.ToString();

        //Ändrar färgen på texten till färgen för den tieren
        tierText.color = tierColors[tier];
        itemText.color = tierColors[tier];

        print("U got " + tierText.text + " item " + itemText.text);
    }
}
