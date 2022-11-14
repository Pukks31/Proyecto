using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuDePausa;
    private bool menuOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuOn = !menuOn;
        }

        if (menuOn == true)
        {
            menuDePausa.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            menuDesactivado();
        } 
    }

    public void continuar()
    {
        menuDesactivado();
        menuOn = false;
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("Menu");
    }

    public void salir()
    {
        Application.Quit();
    }

    private void menuDesactivado()
    {
        menuDePausa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
