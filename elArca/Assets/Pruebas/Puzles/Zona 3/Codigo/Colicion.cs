using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Colicion : MonoBehaviour
{
    static public bool superado, equibocado;
    public bool permitido, final;

    private void Start()
    {
        equibocado = false;
        superado = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Movimientoespecial.enPuzle3 && !permitido)
            {
                equibocado = true;
            }
            else if (final) superado = true;
        }
    }
}
