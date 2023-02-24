using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public Camera cam;
    public GameObject Manager;
    public GameObject boom;
    public GameObject End;
    public Image healthBarimg;
    public bool isHurt;
    public bool alive;
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        End.SetActive(false);
        Manager = GameObject.Find("Spawner");
        HP = 1f;
        isHurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0f) {
            GameObject clone2 = Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(clone2.gameObject, 0.5f);
            clone2.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);
            //SceneManager.LoadScene("End");
            End.SetActive(true);
            alive = false;
        }

        if (HP <= 0.25f) {
            healthBarimg.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.75f);
        }

        else {
            healthBarimg.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.75f);
        }
        HealthFill();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            HP -= 0.1f;
            StartCoroutine(cam.GetComponent<cameraShake>().Shaking());
        }

        if (col.gameObject.tag == "Cat")
        {
            HP -= 0.25f;
            StartCoroutine(cam.GetComponent<cameraShake>().Shaking());
        }

        if (col.gameObject.tag == "Bot")
        {
            HP -= 0.05f;
            StartCoroutine(cam.GetComponent<cameraShake>().Shaking());
        }

        if (col.gameObject.tag == "Cheese")
        {
            if (gameObject.GetComponent<Hunger>().hunger >= 20f)
            {
                gameObject.GetComponent<Hunger>().hunger -= 20f;
            }
            else
            {
                gameObject.GetComponent<Hunger>().hunger = 0f;
            }

            if (HP <= 1f)
            {
                HP += 0.15f;
            }

            if (gameObject.GetComponent<movement>().stamina <= 10f)
            {
                gameObject.GetComponent<movement>().stamina += 2f;
            }
            Manager.GetComponent<Spawner>().numCheese--;
            GameObject clone2 = Instantiate(boom, col.gameObject.transform.position, Quaternion.identity);
            clone2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
            Destroy(clone2.gameObject, 0.5f);
            Destroy(col.gameObject);
        }
    }

    public void HealthFill()
    {
        healthBarimg.fillAmount = HP;
    }
}
