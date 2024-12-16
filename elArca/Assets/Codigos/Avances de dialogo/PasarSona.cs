using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarSona : MonoBehaviour
{
    public GameObject pocicionesJugador, pocicionesCamara;
    public GameObject jugador, camara;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !GLOBAL_Dialogos.enDialogo)
        {
            if (GLOBAL_Dialogos.sona == 0 && GLOBAL_Dialogos.trajeObtenido)
            {
                Avanzar();
            }
            else if (GLOBAL_Dialogos.sona == 1 && GLOBAL_Dialogos.puzzleResuelto)
            {
                jugador.transform.position = pocicionesJugador.transform.position;
                camara.transform.position = pocicionesCamara.transform.position;
                GLOBAL_Dialogos.indiseGeneralHistoria++;
                GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona]++;
                GLOBAL_Dialogos.gradoDialogoAda[GLOBAL_Dialogos.sona]++;
            }
            else if (GLOBAL_Dialogos.sona == 2)
            {
                jugador.transform.position = pocicionesJugador.transform.position;
                camara.transform.position = pocicionesCamara.transform.position;
                GLOBAL_Dialogos.indiseGeneralHistoria = 16;
                GLOBAL_Dialogos.sona++;
            }
        }
    }

    void Avanzar()
    {
        jugador.transform.position = pocicionesJugador.transform.position;
        camara.transform.position = pocicionesCamara.transform.position;
        GLOBAL_Dialogos.sona++;
        GLOBAL_Dialogos.indiseGeneralHistoria++;
        GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona] = 0;
        GLOBAL_Dialogos.gradoDialogoAda[GLOBAL_Dialogos.sona] = 0;
    }
}
