using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public GameObject player;
    public GameObject options;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player(Clone)");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void playMouse() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mouse");
    }

    public void playCat()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Cat");
    }

    public void Back() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void Shop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop");
    }

    public void Pause()
    {
        if (player.GetComponent<health>().alive)
        {
            options.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume() {
        options.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Mode()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mode");
    }


    public void Multiplayer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loading");
    }
}
