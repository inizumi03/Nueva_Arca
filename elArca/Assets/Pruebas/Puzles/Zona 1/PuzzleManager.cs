using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public CableConnection receptorRojo, receptorVerde, receptorAzul; // Referencias a los receptores
    public GameObject canvas; // Referencia a la puerta

    private bool puertaAbierta = false;

    void Update()
    {
        // Si todos los receptores están conectados correctamente
        if (!GLOBAL_Dialogos.trajeObtenido &&
            receptorRojo.EstaConectado() &&
            receptorVerde.EstaConectado() &&
            receptorAzul.EstaConectado())
        {
            TerminarPuzzle();
        }
    }

    private void TerminarPuzzle()
    {
        canvas.SetActive(false);
        GLOBAL_Dialogos.trajeObtenido = true;
        GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona]++;
        GLOBAL_Dialogos.indiseGeneralHistoria++;
    }
}
