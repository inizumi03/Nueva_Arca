using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarYdesactivar : MonoBehaviour
{
    public GameObject objeto; // El objeto que se activará y desactivará

    private void Start()
    {
        // Inicia la corutina que controla el activado y desactivado
        StartCoroutine(CambiarEstadoObjeto());
    }

    private IEnumerator CambiarEstadoObjeto()
    {
        while (true) // Bucle infinito para alternar el estado
        {
            objeto.SetActive(!objeto.activeSelf); // Cambia el estado actual
            yield return new WaitForSeconds(1); // Espera 1 segundo
        }
    }
}
