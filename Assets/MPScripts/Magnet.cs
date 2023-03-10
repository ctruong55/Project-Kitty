using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject Player;
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) <= 5f)  
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * speed);
        }
    }
}
