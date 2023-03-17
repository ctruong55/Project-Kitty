using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coins : MonoBehaviour
{
    public GameObject player;
    public TMP_Text cointxt;

    // Start is called before the first frame update
    void Start()
    {
        cointxt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player(Clone)");
        cointxt.text = "�" + movement.coins.ToString("0");
        if (!player.GetComponent<health>().alive)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1156f, -579f);
        }
        else 
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-80f, -175f);
        }
    }
}
