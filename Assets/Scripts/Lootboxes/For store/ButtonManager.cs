using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPair
    {
        [Header("Button")]
        public Button button;

        [Header("Tmp Texts")]
        public TextMeshProUGUI amountLeftTmp;
        public TextMeshProUGUI purchasedTmp;
        public string offerNameText; // Variable to store previous text for purchasedTmp

        [Header("Values")]
        public int value = 0;
        public int maxClicks; // Maximum number of clicks allowed, set to int.MaxValue for endless clicking
        private DateTime lastClickTime;

        [Header("Type of id")]
        public bool purchasable; // Indicates whether the button can be purchased
        public bool isDaily;
        

        public void Click()
        {
            if (CanClick())
            {
                value++;
                UpdateText();
            }

            if (purchasable && value >= maxClicks)
            {
                button.interactable = false; // Disable button if maximum clicks reached
            }
            else if (purchasable && value < maxClicks)
            {
                button.interactable = true; // Enable button if clicks are available
            }

            if (isDaily)
            {
                value++;
                lastClickTime = DateTime.Now;
                button.interactable = false;
                SaveLastClickTime();
            }
        }

        private bool CanClick()
        {
            if (!purchasable && !isDaily)
                return true; // If not purchasable or daily, allow endless clicking
            else
            {
                if (maxClicks == int.MaxValue)
                    return true; // Endlessly clickable
                else
                    return value < maxClicks;
            }
        }

        internal void UpdateText() // Changed to internal
        {
            if (amountLeftTmp != null)
            {
                if (purchasable)
                {
                    if (maxClicks > value)
                        amountLeftTmp.text = "Available for purchase: " + (maxClicks - value).ToString(); // Show remaining clicks
                    else
                        amountLeftTmp.text = ""; // Clear text when maximum clicks reached
                }
                else if (isDaily)
                {
                    TimeSpan timeLeft = GetTimeLeft();
                    amountLeftTmp.text = String.Format("{0:D2}:{1:D2}:{2:D2}", timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds);
                }
            }

            if (purchasedTmp != null)
            {
                if (purchasable && value >= maxClicks)
                {
                    // Do not update offerNameText if it's not already set
                    if (String.IsNullOrEmpty(offerNameText))
                    {
                        offerNameText = purchasedTmp.text; // Store previous text
                    }
                    purchasedTmp.text = "Purchased";
                }
                else
                {
                    // Restore previous text if offerNameText is set
                    if (!String.IsNullOrEmpty(offerNameText))
                    {
                        purchasedTmp.text = offerNameText;
                    }
                }
            }
        }

        private TimeSpan GetTimeLeft()
        {
            TimeSpan timeSinceLastClick = DateTime.Now - lastClickTime;
            TimeSpan timeLeft = TimeSpan.FromDays(1) - timeSinceLastClick;
            return timeLeft;
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

            UpdateText(); // Update the text immediately after initializing
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

    private void Update()
    {
        // Update the text for all button pairs every frame
        foreach (var pair in buttonPairs)
        {
            pair.UpdateText();

            // Update interactability for purchasable buttons
            if (pair.purchasable && pair.value < pair.maxClicks)
            {
                pair.button.interactable = true;
            }
        }
    }
}
