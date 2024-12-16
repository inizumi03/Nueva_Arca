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
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void ControlMovimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 && z != 0)
        {
            if (x > 0)
            {
                if (z > 0)
                {
                    z = 1;
                    x = 0;
                }
                else
                {
                    x = 1;
                    z = 0;
                }
            }
            else
            {
                if (z > 0)
                {
                    x = -1;
                    z = 0;
                }
                else
                {
                    z = -1;
                    x = 0;
                }
            }
        }
        else if (x != 0)
        {
            z = x;
        }
        else if (z != 0)
        {
            x = -z;
        }

        rb.velocity = new Vector3(x, 0, z) * velocidad;
    }

    void Llamar()
    {
        if (GLOBAL_Dialogos.sona < 3)
        {
            if (Input.GetKeyDown(KeyCode.E) && GLOBAL_Dialogos.trajeObtenido)
                LlamarAAda.Invoke();
            else if (Input.GetKeyDown(KeyCode.Q))
                LlamarADex.Invoke();
        }
    }
}
