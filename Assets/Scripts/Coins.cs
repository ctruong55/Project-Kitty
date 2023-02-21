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
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cointxt.text = "×" + player.GetComponent<movement>().coins.ToString("0");
    }
}
