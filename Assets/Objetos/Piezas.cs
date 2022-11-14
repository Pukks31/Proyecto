using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piezas : MonoBehaviour
{
    public GameObject ObjPuntos;
    public int puntosQueDa;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ObjPuntos.GetComponent<Puntos>().piezas += puntosQueDa;
            Destroy((gameObject));
        }
    }
}
