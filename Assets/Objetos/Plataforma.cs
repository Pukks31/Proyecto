using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plataforma : MonoBehaviour
{
    public Puntos puntos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && puntos.piezas >= 5)
        {
            SceneManager.LoadScene("Completado");
        }
    }
}
