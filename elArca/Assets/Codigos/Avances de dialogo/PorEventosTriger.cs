using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorEventosTriger : MonoBehaviour
{
    public bool sona;
    public bool indiceGeneralHistoria;
    public bool gradoDialogoDex;
    public bool gradoDialogoAda;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (sona) GLOBAL_Dialogos.sona++;
            if (indiceGeneralHistoria) GLOBAL_Dialogos.indiseGeneralHistoria++;
            if (gradoDialogoDex) GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona]++;
            if (gradoDialogoAda) GLOBAL_Dialogos.gradoDialogoAda[GLOBAL_Dialogos.sona]++;

            if (GLOBAL_Dialogos.indiseGeneralHistoria != 9) gameObject.SetActive(false);
        }
    }
}
