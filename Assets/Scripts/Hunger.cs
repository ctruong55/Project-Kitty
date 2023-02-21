using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour
{
    public bool energy;
    public float hunger;
    public Image hungerBarimg;

    // Start is called before the first frame update
    void Start()
    {
        energy = true;
        hunger = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (hunger <= 100f)
        {
            hunger += (4 * Time.deltaTime);
        }

        if (hunger <= 10f)
        {
            energy = true;
        }

        else if (hunger <= 40f)
        {
            energy = false;
            gameObject.GetComponent<health>().HP -= (0.015f * Time.deltaTime);

        }

        else if (hunger <= 70)
        {
            energy = false;
            gameObject.GetComponent<health>().HP -= (0.025f * Time.deltaTime);
            gameObject.GetComponent<movement>().stamina -= (0.25f * Time.deltaTime);
        }
        else
        {
            energy = false;
            gameObject.GetComponent<health>().HP -= (0.075f * Time.deltaTime);
            gameObject.GetComponent<movement>().stamina -= (0.5f * Time.deltaTime);
        }

        HungerFill();
    }

    public void HungerFill()
    {
        hungerBarimg.fillAmount = 1 - (hunger / 100);
    }
}
