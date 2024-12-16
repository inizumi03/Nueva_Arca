using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCientifica : MonoBehaviour
{
    public GameObject contraseña;

    private void Update()
    {
        if (ComprobacionContraseña.completo) enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            contraseña.SetActive(true);
        }
    }
}
