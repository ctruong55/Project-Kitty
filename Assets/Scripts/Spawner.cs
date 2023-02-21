using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject botPrefab;
    public GameObject cheesePrefab;
    public GameObject catPrefab;
    public GameObject coinPrefab;
    public GameObject[] forestPrefabs;
    public float numBots;
    public float forestObstacles;
    public float numCheese;
    public float maxCheese = 5f;
    public float numCoins;
    public float maxCoins = 10f;

    // Start is called before the first frame update
    void Start()
    {
        catPrefab = GameObject.FindGameObjectWithTag("Cat"); 
        numCheese = 0f;
        numCoins = 0f;
        spawnBots();
        spawnForestObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        spawnCheese();
        spawnCoins();
    }


    void spawnBots() {
        for (int i = 0; i < numBots; i++)
        {
            catPrefab.GetComponent<CatBot>().mice.Add(Instantiate(botPrefab, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity));
        }
    }

    void spawnCheese() {
        if ((numCheese < maxCheese) && (numCheese >= 0)) {
            Instantiate(cheesePrefab, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
            numCheese++;
        }
    }

    void spawnCoins()
    {
        if ((numCoins < maxCoins) && (numCoins >= 0))
        {
            Instantiate(coinPrefab, new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
            numCoins++;
        }
    }

    void spawnForestObstacles()
    {
        for (int i = 0; i < forestObstacles; i++)
        {
            Instantiate(forestPrefabs[Random.Range(0, 13)], new Vector2(Random.Range(-50f, 50f), Random.Range(-33f, 33f)), Quaternion.identity);
        }
    }
}
