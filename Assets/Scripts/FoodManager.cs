using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public int FoodCount = 0; // Food amount
    public Text foodText; // Food display text
    public GameObject soldierAntPrefab;  // Reference to the SoldierAnt prefab
    public GameObject workerAntPrefab;   // Reference to the WorkerAnt prefab
    public Transform spawnPoint;         // Where the ant should spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateFoodDisplay()
    {
        foodText.text = "Food: " + FoodCount.ToString();
    }

    public void AddFood(int amount)
    {
        FoodCount += amount;
        UpdateFoodDisplay();  // Update the UI after adding food
    }

    void SpawnAnt(GameObject antPrefab)
    {
        if (antPrefab != null && spawnPoint != null)
        {
            Instantiate(antPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
