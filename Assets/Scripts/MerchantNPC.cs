using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantNPC : MonoBehaviour
{
    public GameObject merchantUI; // Assign UI Panel in Inspector
    public int soldierAntCost = 10;
    public int workerAntCost = 5;

    private FoodManager foodManager;

    void Start()
    {
        foodManager = FindObjectOfType<FoodManager>(); // Get reference to FoodManager
    }

    public void BuySoldierAnt()
    {
        if (foodManager.FoodCount >= soldierAntCost) // Check if player has enough Food
        {
            foodManager.FoodCount -= soldierAntCost; // Deduct Food
            foodManager.SpawnAnt(foodManager.soldierAntPrefab); // Spawn Soldier Ant
        }
    }

    public void BuyWorkerAnt()
    {
        if (foodManager.FoodCount >= workerAntCost) // Check if player has enough Food
        {
            foodManager.FoodCount -= workerAntCost; // Deduct Food
            foodManager.SpawnAnt(foodManager.workerAntPrefab); // Spawn Worker Ant
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            merchantUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            merchantUI.SetActive(false);
        }
    }
}