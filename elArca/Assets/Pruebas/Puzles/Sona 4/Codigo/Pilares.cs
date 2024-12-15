using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pilares : MonoBehaviour
{
    public Color mColor;
    public GameObject plataforma;

    public delegate void DelegadoBorrarColores(Color pColor);
    static public event DelegadoBorrarColores BorrarColores;

    void Start()
    {
        GetComponent<Renderer>().material.color = mColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            if (collision.gameObject.GetComponent<Renderer>().material.color == mColor)
            {
                BorrarColores.Invoke(mColor);
                plataforma.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
