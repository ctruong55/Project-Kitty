using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Timer : MonoBehaviour
{
    public Camera cam;
    public GameObject Mouse;
    public GameObject Mist;
    public GameObject Lightrays;
    public GameObject fireworks;
    public Light2D spotLight;
    public bool celebrate;
    public float timeLeft;
    public float tempTime;
    public TMP_Text time;
    public Volume volume;

    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = 30f;
        volume.weight = 0f;
        Lightrays.SetActive(true);
        Mist.SetActive(false);
        time = GetComponent<TMP_Text>();
        celebrate = false;
        tempTime = (timeLeft * 0.75f);
        InvokeRepeating("roundOver", 10f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= (Time.deltaTime);

        if (volume.weight <= 1f) {
            volume.weight += (Time.deltaTime / (tempTime - 1f));
        }

        if (volume.weight >= 0.75f && spotLight.intensity >= 0f)
        {
            spotLight.intensity -= (Time.deltaTime / 10f);
        }

        else if (volume.weight >= 0.50f)
        {
            Mist.SetActive(true);
        }

        else if (volume.weight >= 0.25f) {
            Lightrays.SetActive(false);
        }

        time.text = ((int)(timeLeft / 60)).ToString("0") + ":" + (timeLeft % 60).ToString("00");

        if (timeLeft < 1)
        {
            time.text = "ROUND WON";
            celebrate = true;
        }

        if (cam.orthographicSize >= 10f) {
            cam.orthographicSize -= ((timeLeft/(1.5f * tempTime)) * Time.deltaTime);
        }
    }

    void roundOver() {
        if (celebrate) {
            GameObject clone = Instantiate(fireworks, Mouse.transform.position, Quaternion.identity);
            clone.transform.localScale = new Vector2(25f, 25f);
            Destroy(clone, 1f);
        }
    }
}
