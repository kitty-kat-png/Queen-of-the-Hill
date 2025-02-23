using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public int ItemID;
    public Text PriceText;
    public Text antAmountText;
    public GameObject ShopManagerVar;

    // Update is called once per frame
    void Update()
    {
        PriceText.text = "Food: " + ShopManagerVar.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        antAmountText.text = "Ants: " + ShopManagerVar.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
}
