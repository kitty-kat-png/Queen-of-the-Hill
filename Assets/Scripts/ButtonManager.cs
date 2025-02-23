using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public int ItemID; // 1 for Worker Ant, 2 for Soldier Ant
    public Text PriceText; // To show the price of the item
    public Text antAmountText; // To show the number of ants purchased
    public GameObject ShopManagerVar; // Reference to the ShopManager

    private int workerAntCost = 5; // Cost for Worker Ant
    private int soldierAntCost = 10; // Cost for Soldier Ant

    void Update()
    {
        // Update PriceText based on the ItemID (1 = Worker Ant, 2 = Soldier Ant)
        if (ItemID == 1)
        {
            PriceText.text = "Food: " + workerAntCost.ToString(); // Show Worker Ant price
        }
        else if (ItemID == 2)
        {
            PriceText.text = "Food: " + soldierAntCost.ToString(); // Show Soldier Ant price
        }

        // Update antAmountText based on the amount of ants purchased (using FoodManager to get the count)
        if (ItemID == 1)
        {
            antAmountText.text = "Ants: " + ShopManagerVar.GetComponent<FoodManager>().AntCount.ToString(); // Worker Ant count
        }
        else if (ItemID == 2)
        {
            antAmountText.text = "Ants: " + ShopManagerVar.GetComponent<FoodManager>().AntCount.ToString(); // Soldier Ant count
        }
    }
}
