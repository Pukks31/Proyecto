using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private GameObject camara;

    [Header("Estadisticas normales")] 
    [SerializeField] private float velocidad;
    [SerializeField] private float velCorriendo;
    [SerializeField] private float alturaDeSalto;
    [SerializeField] private float tiempoAlGirar;

    [Header("Datos sobre el piso")] 
    [SerializeField] private Transform detectaPiso;
    [SerializeField] private float distanciaPiso;
    [SerializeField] private LayerMask mascaraPiso;

    float velocidadGiro;
    float gravedad = -9.81f;
    Vector3 velocity;
    bool tocarPiso;

    public AudioSource pasos;
    private bool Hactivo;
    private bool Vactivo;

    Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        camara = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        tocarPiso = Physics.CheckSphere(detectaPiso.position, distanciaPiso, mascaraPiso);

        if (tocarPiso && velocity.y < 0)
        {
            velocity.y = -2f;
            anim.SetBool("Salto", false);
        }

        if (!tocarPiso)
        {
            anim.SetBool("Salto", true);
        }

        if (Input.GetButtonDown("Jump") && tocarPiso)
        {
            velocity.y = Mathf.Sqrt(alturaDeSalto * -2 * gravedad);
            anim.SetBool("Salto", true);
        }

        velocity.y += gravedad * 3 * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;

        if (direccion.magnitude <= 0)
        {
            anim.SetFloat("movimientos", 0, 0.1f, Time.deltaTime);
        }

        if (direccion.magnitude >= 0.1f)
        {
            float objetivoAngluo = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.transform.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, objetivoAngluo, ref velocidadGiro,
                tiempoAlGirar);
            transform.rotation = Quaternion.Euler(0, angulo, 0);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Vector3 mover = Quaternion.Euler(0, objetivoAngluo, 0) * Vector3.forward;
                controller.Move(mover.normalized * velCorriendo * Time.deltaTime);  
                anim.SetFloat("movimientos", 1, 0.1f, Time.deltaTime);
            }
            else
            {
                Vector3 mover = Quaternion.Euler(0, objetivoAngluo, 0) * Vector3.forward;
                controller.Move(mover.normalized * velocidad * Time.deltaTime);
                anim.SetFloat("movimientos", 0.5f, 0.1f, Time.deltaTime);
            }
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            if (Vactivo == false)
            {
                Hactivo = true;
                pasos.Play();    
            }
        }

        if (Input.GetButtonDown("Vertical"))
        {
            if (Hactivo == false)
            {
                Vactivo = true;
                pasos.Play();    
            }
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            
            if (Vactivo == false)
            {
                pasos.Pause();    
            }
        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            
            if (Hactivo == false)
            {
                pasos.Pause();    
            }
        }
    }
}
