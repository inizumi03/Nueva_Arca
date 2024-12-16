using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDePausa : MonoBehaviour
{
    public GameObject canvasPausa; // Asigna el Canvas del menú de pausa en el Inspector
    private bool juegoPausado = false;

    void Update()
    {
        // Verifica si se presionó la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si el juego está pausado, reanudar; si no, pausar
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    // Función para pausar el juego
    public void PausarJuego()
    {
        canvasPausa.SetActive(true); // Activa el Canvas de pausa
        Time.timeScale = 0f; // Detiene el tiempo
        juegoPausado = true;
    }

    // Función para reanudar el juego
    public void ReanudarJuego()
    {
        canvasPausa.SetActive(false); // Desactiva el Canvas de pausa
        Time.timeScale = 1f; // Reanuda el tiempo
        juegoPausado = false;
    }
}
