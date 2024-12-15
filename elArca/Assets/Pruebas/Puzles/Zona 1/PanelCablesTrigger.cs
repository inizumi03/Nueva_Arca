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
            Debug.Log("Jugador entró en la zona.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador sale
        {
            playerInZone = false;
            Debug.Log("Jugador salió de la zona.");
        }
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F) && !GLOBAL_Dialogos.enDialogo) // Si está en la zona y presiona "E"
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
