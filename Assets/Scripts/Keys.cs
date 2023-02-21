using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keys : MonoBehaviour
{
    public GameObject player;
    public TMP_Text keytxt;

    // Start is called before the first frame update
    void Start()
    {
        keytxt = GetComponent<TMP_Text>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        keytxt.text = "×" + player.GetComponent<movement>().keys.ToString("0");
    }
}
