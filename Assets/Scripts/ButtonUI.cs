using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMouse() {
        SceneManager.LoadScene("Mouse");
    }

    public void playCat()
    {
        SceneManager.LoadScene("Cat");
    }

    public void Back() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Title");
    }
}
