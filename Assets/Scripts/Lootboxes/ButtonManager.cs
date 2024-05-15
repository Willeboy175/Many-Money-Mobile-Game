using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPair
    {
        public Button button;
        public TextMeshProUGUI tmpText;
        public int value = 0;
        public int maxClicks; // Maximum number of clicks allowed, set to int.MaxValue for endless clicking
        public bool purchasable; // Indicates whether the button can be purchased
        public bool isDaily;
        private DateTime lastClickTime;

        public void Click()
        {
            if (CanClick())
            {
                value++;
                UpdateText();
            }
            if (purchasable) {
                value++;
                if (value >= maxClicks)
                {
                   
                    button.interactable = false; // Disable button if maximum clicks reached
                }
            }
            if (isDaily)
            {
                value++;
                lastClickTime = DateTime.Now;
                SaveLastClickTime();
            }
        }

        private bool CanClick()
        {
            if (!purchasable && !isDaily)
                return true; // If not purchasable, allow endless clicking
            else
            {
                if (maxClicks == int.MaxValue)
                    return true; // Endlessly clickable
                else
                    return value < maxClicks;
            }
        }

        private void UpdateText()
        {
            if (tmpText != null)
            {
                if (maxClicks > value && purchasable || isDaily)
                    tmpText.text = (maxClicks - value).ToString(); // Show remaining clicks
 
                else 
                    tmpText.text = "";
            }
        }

        private bool IsAvailable()
        {
            return DateTime.Now >= lastClickTime.AddDays(1);
        }

        private void LoadLastClickTime()
        {
            string lastClickTimeString = PlayerPrefs.GetString(button.name + "_LastClickTime", DateTime.MinValue.ToString());
            lastClickTime = DateTime.Parse(lastClickTimeString);
        }

        private void SaveLastClickTime()
        {
            PlayerPrefs.SetString(button.name + "_LastClickTime", lastClickTime.ToString());
        }

        public void Initialize()
        {
            if (isDaily)
                LoadLastClickTime();

            UpdateText();
            button.onClick.AddListener(Click);
        }
    }

    public ButtonPair[] buttonPairs;

    private void Start()
    {
        // Initialize each pair
        foreach (var pair in buttonPairs)
        {
            pair.Initialize();
        }
    }
}
