using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private bool pauseMenu = false;

    public GameObject menuEmpty;


    void Start()
    {
        closePauseMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu = !pauseMenu;
        }
    }

    void FixedUpdate()
    {
        if (pauseMenu)
        {
            menuEmpty.SetActive(true);
        }
        else
        {
            menuEmpty.SetActive(false);
        }
    }

    public void closePauseMenu()
    {
        pauseMenu = false;
    }
}
