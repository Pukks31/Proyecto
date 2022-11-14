using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Jugar()
    {
        SceneManager.LoadScene("juego");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
