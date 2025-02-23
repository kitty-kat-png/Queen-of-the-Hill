using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodManager : MonoBehaviour
{
    public int FoodCount = 0; // Food amount
    public int AntCount = 0; // Ant army amount
    public Text foodText; // Food display text
    public Text antText; //Ant display text
    public GameObject queenDoor;
    private bool doorDestroyed;
    public GameObject soldierAntPrefab;  // Reference to the SoldierAnt prefab
    public GameObject workerAntPrefab;   // Reference to the WorkerAnt prefab
    public Transform spawnPoint;         // Where the ant should spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = "Food: " + FoodCount.ToString();
        antText.text = "Ants: " + AntCount.ToString();

        if(AntCount == 100)
        {
            doorDestroyed = true;
            Destroy(queenDoor);
        }
    }

    public void AddFood(int amount)
    {
        FoodCount += amount;
    }

    public void SpawnAnt(GameObject antPrefab)
    {
        if (antPrefab != null && spawnPoint != null)
        {
            Instantiate(antPrefab, spawnPoint.position, Quaternion.identity);
            AntCount++;
        }
    }
}
