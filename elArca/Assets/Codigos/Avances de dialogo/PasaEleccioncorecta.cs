using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasaEleccioncorecta : MonoBehaviour
{
    public GameObject jugador, camara, pj, pc;

    void Update()
    {
       if (GLOBAL_Dialogos.eleccionCorrecta)
        {
            jugador.transform.position = pj.transform.position;
            camara.transform.position = pc.transform.position;
            GLOBAL_Dialogos.sona = 2;
            GLOBAL_Dialogos.indiseGeneralHistoria++;
            GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona] = 0;
            GLOBAL_Dialogos.gradoDialogoAda[GLOBAL_Dialogos.sona] = 0;
            gameObject.SetActive(false);
        } 
    }
}
