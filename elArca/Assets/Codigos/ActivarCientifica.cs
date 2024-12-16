using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCientifica : MonoBehaviour
{
    public GameObject contrase�a;

    private void Update()
    {
        if (ComprobacionContrase�a.completo) enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            contrase�a.SetActive(true);
        }
    }
}
