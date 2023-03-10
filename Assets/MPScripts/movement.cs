using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class movement : MonoBehaviourPunCallbacks
{
    public GameObject Manager;
    public Camera cam;
    public GameObject Fireworks;
    public static float coins = 0;
    public float keys = 0;
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    public Image staminaBarimg;
    private float speed;
    public float NormalSpeed = 15f;
    public float stamina = 10f;
    public bool ready;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Spawner");
        speed = NormalSpeed;
        view = GetComponent<PhotonView>();
        staminaBarimg = GameObject.Find("Canvas").transform.GetChild(7).gameObject.GetComponent<Image>();
        cam.orthographicSize = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<health>().alive && ready && view.IsMine) {
            staminaBarimg = GameObject.Find("Canvas").transform.GetChild(7).gameObject.GetComponent<Image>();
            rotation();
            thrust();
            StaminaFill();
        }
    }


    public void rotation() {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(0f, 0f, 5f);
            cam.transform.Rotate(0f, 0f, -5f);
            Debug.Log(gameObject.GetComponent<health>().alive && ready && view.IsMine);
        }

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(0f, 0f, -5f);
            cam.transform.Rotate(0f, 0f, 5f);
        }

        else
        {
            float rand = Random.Range(-0.5f, 0.5f);
            transform.Rotate(0f, 0f, rand);
            cam.transform.Rotate(0f, 0f, -rand);
        }
    }

    public void thrust() {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        dust.Play();
        if (stamina > 0f && ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))))
        {
            speed = 400f;
            stamina -= (2 * Time.deltaTime);
        }

        else if (stamina < 10f && !((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))))
        {
            StartCoroutine("Regen", 3f);
        }

        else {

            speed = NormalSpeed;

        }
    }


    IEnumerator Regen(float duration)
    {
        speed = NormalSpeed;
        yield return new WaitForSeconds(duration);
        if (stamina < 10f && !((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) && gameObject.GetComponent<Hunger>().energy) {
            stamina += Time.deltaTime;
        }
    }

    public void StaminaFill()
    {
        staminaBarimg.fillAmount = stamina / 10;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            coins++;
            Manager.GetComponent<Spawner>().numCoins--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Key")
        {
            keys++;
            GameObject clone2 = Instantiate(Fireworks, col.gameObject.transform.position, Quaternion.identity);
            Destroy(clone2.gameObject, 1f);
            Destroy(col.gameObject);
        }
    }

}
