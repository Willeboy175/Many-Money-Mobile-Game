using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonsManager : MonoBehaviour
{
    [System.Serializable]
    public class ButtonTMPPair
    {
        public Button button;
        public TextMeshProUGUI tmpText;
        public int value = 0; // Add a field to store the value
    }

    public ButtonTMPPair[] buttonTMPPairs;

    private void Start()
    {
        // Subscribe to button click events
        foreach (var pair in buttonTMPPairs)
        {
            pair.button.onClick.AddListener(() => ChangeText(pair));
        }
    }

    private void ChangeText(ButtonTMPPair pair)
    {
        pair.value++;
        pair.tmpText.text = pair.value.ToString();
    }
}
