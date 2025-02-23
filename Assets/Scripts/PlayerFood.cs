using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFood : MonoBehaviour
{
    public int food = 0;  // Amount of food the player has
    public Text foodText; // Reference to the UI Text element
    public GameObject soldierAntPrefab;  // Reference to the SoldierAnt prefab
    public GameObject workerAntPrefab;   // Reference to the WorkerAnt prefab
    public Transform spawnPoint;         // Where the ant should spawn

    void Start()
    {
        // Initialize the food display when the game starts
        UpdateFoodDisplay();
    }

    // Method to add food to the player
    public void AddFood(int amount)
    {
        food += amount;
        UpdateFoodDisplay();  // Update the UI after adding food
    }

    // Method to update the food display on the screen
    void UpdateFoodDisplay()
    {
        foodText.text = "Food: " + food.ToString();  // Update the UI Text with the current food amount
    }

    // Method for the player to turn in food and spawn an ant
    public void TurnInFood(int foodCost, bool spawnSoldier)
    {
        // Check if the player has enough food
        if (food >= foodCost)
        {
            // Deduct the food
            food -= foodCost;
            UpdateFoodDisplay();  // Update the UI after deducting food

            // Spawn either SoldierAnt or WorkerAnt
            if (spawnSoldier)
            {
                SpawnAnt(soldierAntPrefab);  // Spawn SoldierAnt
            }
            else
            {
                SpawnAnt(workerAntPrefab);   // Spawn WorkerAnt
            }
        }
        else
        {
            Debug.Log("Not enough food to turn in!");
        }
    }

    // Method to spawn an ant at a specified point
    void SpawnAnt(GameObject antPrefab)
    {
        if (antPrefab != null && spawnPoint != null)
        {
            Instantiate(antPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}

