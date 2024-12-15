using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidad;

    public delegate void LlamarAPersonaje();

    static public event LlamarAPersonaje LlamarAAda, LlamarADex;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GLOBAL_Dialogos.enDialogo && !Movimientoespecial.enPuzle3)
        {
            ControlMovimiento();
            Llamar();
        }
    }

    void ControlMovimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(x, 0, z) * velocidad;
    }

    void Llamar()
    {
        if (Input.GetKeyDown(KeyCode.E))
            LlamarAAda.Invoke();
        else if (Input.GetKeyDown(KeyCode.Q))
            LlamarADex.Invoke();
    }
}
