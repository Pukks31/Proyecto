using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverInicio : MonoBehaviour
{
    public void Inicio()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Juego()
    {
        SceneManager.LoadScene("juego");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
