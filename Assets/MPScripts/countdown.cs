using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countdown : MonoBehaviour
{
    public GameObject bot;
    public GameObject player;
    public GameObject cat;
    public float countdownTime;
    public TMP_Text countdownDisplay;

    void Awake()
    {
        player = GameObject.Find("Player(Clone)");
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player(Clone)");
        //player.GetComponent<movement>().ready = false;
        cat.GetComponent<CatBot>().gameReady = false;
        StartCoroutine(CountdownStart());
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player(Clone)");
    }

    IEnumerator CountdownStart() {
        while (countdownTime > 0) {
            countdownDisplay.text = countdownTime.ToString("0");
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        player.GetComponent<movement>().ready = true;
        cat.GetComponent<CatBot>().gameReady = true;
        countdownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
