using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Global : MonoBehaviour
{
    public int sona, gradoDialogoAda, gradoDialogoDex, gradoHistoria, indiseGeneralHistoria;
    public bool tengoTraje;
    void Start()
    {
        GLOBAL_Dialogos.sona = 0;
        GLOBAL_Dialogos.gradoDialogoAda = new int[3];
        GLOBAL_Dialogos.gradoDialogoDex = new int[3];
    }

    void Update()
    {
        GLOBAL_Dialogos.sona = sona;
        GLOBAL_Dialogos.gradoDialogoAda[GLOBAL_Dialogos.sona] = gradoDialogoAda;
        GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona] = gradoDialogoDex;
        GLOBAL_Dialogos.trajeObtenido = tengoTraje;
        indiseGeneralHistoria = GLOBAL_Dialogos.indiseGeneralHistoria;

        if (Input.GetKeyDown(KeyCode.P))
            GLOBAL_Dialogos.indiseGeneralHistoria++;
        else if (Input.GetKeyDown(KeyCode.O))
            GLOBAL_Dialogos.indiseGeneralHistoria--;
        else if (Input.GetKeyDown(KeyCode.C))
            GLOBAL_Dialogos.dialogosCientifica = !GLOBAL_Dialogos.dialogosCientifica;
    }
}
