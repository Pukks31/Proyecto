using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    Transform Player;
    float distancia;
    public float maxDistancia;
    public Transform torreta, cannon;
    public GameObject proyectil;
    public float radioDisparo, siguienteDisparo;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distancia = Vector3.Distance(Player.position, transform.position);
        if (distancia <= maxDistancia)
        {
            torreta.LookAt(Player);
            if (Time.time >= siguienteDisparo)
            {
                siguienteDisparo = Time.time + 1f / radioDisparo;
                disparo();
            }
        }
    }

    void disparo()
    {
        GameObject clone = Instantiate(proyectil, cannon.position, torreta.rotation);
        clone.GetComponent<Rigidbody>().AddForce(torreta.forward * 2500);
        Destroy(clone, 3);
    }
}
