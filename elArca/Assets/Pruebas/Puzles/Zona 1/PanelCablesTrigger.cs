using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCablesTrigger : MonoBehaviour
{
    public GameObject panelCables; // Referencia al Canvas
    private bool playerInZone = false; // Verifica si el jugador está en la zona

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador entra
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador sale
        {
            playerInZone = false;
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F) && !GLOBAL_Dialogos.enDialogo && !GLOBAL_Dialogos.trajeObtenido) // Si está en la zona y presiona "E"
        {
            if (panelCables != null)
            {
                // Alterna el estado del panel
                panelCables.SetActive(true);
            }
            else
            {
                Debug.LogWarning("PanelCables no está asignado en el Inspector.");
            }
        }
    }
}
