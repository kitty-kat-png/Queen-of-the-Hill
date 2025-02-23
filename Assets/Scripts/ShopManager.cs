using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public Text foodText; // UI text to show available Food
    private FoodManager foodManager; // Reference to FoodManager

    // Define item costs
    private int soldierAntCost = 2;
    private int workerAntCost = 1;

    void Start()
    {
        foodManager = FindObjectOfType<FoodManager>(); // Get FoodManager reference
        UpdateUI();
    }

    void UpdateUI()
    {
        foodText.text = "Food: " + foodManager.FoodCount.ToString();
    }

    public void Buy()
    {
        GameObject buttonRef = EventSystem.current.currentSelectedGameObject;

        if (buttonRef != null)
        {
            ButtonManager buttonManager = buttonRef.GetComponent<ButtonManager>();

            if (buttonManager != null)
            {
                int itemID = buttonManager.ItemID;
                int cost = (itemID == 1) ? workerAntCost : (itemID == 2) ? soldierAntCost : 0;
                GameObject antPrefab = (itemID == 1) ? foodManager.workerAntPrefab : (itemID == 2) ? foodManager.soldierAntPrefab : null;

                if (foodManager.FoodCount >= cost && antPrefab != null)
                {
                    foodManager.FoodCount -= cost; // Deduct food
                    foodManager.SpawnAnt(antPrefab); // Spawn the purchased ant

                    // Update UI
                    UpdateUI();
                    buttonManager.antAmountText.text = (int.Parse(buttonManager.antAmountText.text) + 1).ToString();
                }
            }
        }
    }
}
