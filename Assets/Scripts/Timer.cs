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
    public GameObject player;
    public GameObject Mist;
    public GameObject Lightrays;
    public Light2D spotLight;
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
        tempTime = (timeLeft * 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<health>().alive)
        {
            timeLeft -= (Time.deltaTime);

            if (volume.weight <= 1f)
            {
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

            else if (volume.weight >= 0.25f)
            {
                Lightrays.SetActive(false);
            }

            time.text = ((int)(timeLeft / 60)).ToString("0") + ":" + (timeLeft % 60).ToString("00");

            if (timeLeft < 1)
            {
                time.text = "ROUND WON";
                player.GetComponent<health>().alive = false;
            }

            if (cam.orthographicSize >= 10f)
            {
                cam.orthographicSize -= ((timeLeft / (1.5f * tempTime)) * Time.deltaTime);
            }
        }
        else {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-40f, -579f);
            volume.weight = 1f;
            spotLight.intensity -= 0f;
            Mist.SetActive(true);
            Lightrays.SetActive(false);
        }
    }
}
