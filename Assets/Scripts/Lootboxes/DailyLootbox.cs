using UnityEngine;
using UnityEngine.UI;
using System;

public class DailyLootbox : MonoBehaviour
{
    public Button button;

    private DateTime lastClickTime;

    void Start()
    {
        // Load the last click time from player preferences
        LoadLastClickTime();

        // Update button interactability based on availability
        UpdateButtonInteractability();
    }

    public void Click()
    {
        // Check if the button is available
        if (DateTime.Now >= lastClickTime.AddDays(1))
        {
            // Grant reward or perform action here

            // Update last click time
            lastClickTime = DateTime.Now;
            SaveLastClickTime();

            // Update button interactability
            UpdateButtonInteractability();
        }
    }

    private void UpdateButtonInteractability()
    {
        // Check if the button is available
        button.interactable = DateTime.Now >= lastClickTime.AddDays(1);
    }

    private void LoadLastClickTime()
    {
        string lastClickTimeString = PlayerPrefs.GetString("LastClickTime", DateTime.MinValue.ToString());
        lastClickTime = DateTime.Parse(lastClickTimeString);
    }

    private void SaveLastClickTime()
    {
        PlayerPrefs.SetString("LastClickTime", lastClickTime.ToString());
    }
}
