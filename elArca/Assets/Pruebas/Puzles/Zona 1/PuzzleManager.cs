using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public CableConnection receptorRojo, receptorVerde, receptorAzul; // Referencias a los receptores
    public GameObject puerta; // Referencia a la puerta

    private bool puertaAbierta = false;

    void Update()
    {
        // Si todos los receptores están conectados correctamente
        if (!puertaAbierta &&
            receptorRojo.EstaConectado() &&
            receptorVerde.EstaConectado() &&
            receptorAzul.EstaConectado())
        {
            AbrirPuerta();
        }
    }

    private void AbrirPuerta()
    {
        puerta.SetActive(false); // Desactiva la puerta
        puertaAbierta = true; // Evita abrir la puerta múltiples veces
        Debug.Log("¡Puzzle completado! La puerta se ha abierto.");
    }
}
