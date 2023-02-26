using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public float coins;
    public TMP_Text coinTxt;

    // Start is called before the first frame update
    void Start()
    {
        coinTxt.text = "Coins: " + coins.ToString();

        //IDs
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quantity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, buttonRef.GetComponent<ItemInfo>().ItemID]) {

            coins -= shopItems[2, buttonRef.GetComponent<ItemInfo>().ItemID];
            shopItems[3, buttonRef.GetComponent<ItemInfo>().ItemID]++;
            coinTxt.text = "Coins: " + coins.ToString();
            buttonRef.GetComponent<ItemInfo>().QuantityTxt.text = shopItems[3, buttonRef.GetComponent<ItemInfo>().ItemID].ToString();
        }
    }
}
