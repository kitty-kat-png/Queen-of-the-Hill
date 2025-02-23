using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[3,2];
    public int FoodCount;
    public Text foodText;
    
    // Start is called before the first frame update
    void Start()
    {
        foodText.text = "Food: " + FoodCount.ToString();
        
        // IDs
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;

        // Prices
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 3;

        // Ant Amounts
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Shop").GetComponent<EventSystem>().currentSelectedGameObject;

        if (FoodCount >= shopItems[2, ButtonRef.GetComponent<ButtonManager>().ItemID])
        {
            FoodCount -= shopItems[2, ButtonRef.GetComponent<ButtonManager>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonManager>().ItemID]++;
            foodText.text = "Food: " + FoodCount.ToString();
            ButtonRef.GetComponent<ButtonManager>().antAmountText.text = shopItems[3, ButtonRef.GetComponent<ButtonManager>().ItemID].ToString();

        }
    }
}
