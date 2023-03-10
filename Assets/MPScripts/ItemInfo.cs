using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text Pricetxt;
    public TMP_Text QuantityTxt;
    public GameObject ShopManager;


    void Update() {

        Pricetxt.text = "Price: $ " + ShopManager.GetComponent<Shop>().shopItems[2,ItemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<Shop>().shopItems[3, ItemID].ToString();
    }
}
