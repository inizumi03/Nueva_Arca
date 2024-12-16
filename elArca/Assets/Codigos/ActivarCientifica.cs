using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCientifica : MonoBehaviour
{
    public GameObject contraseņa;

    private void Update()
    {
        if (ComprobacionContraseņa.completo) enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            contraseņa.SetActive(true);
        }
    }
}
