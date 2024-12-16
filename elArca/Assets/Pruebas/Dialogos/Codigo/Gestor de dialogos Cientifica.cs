using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestordedialogosCientifica : MonoBehaviour
{
    public GameObject canvas, opcines, imajenFondo;
    public TextMeshProUGUI texto;
    int dialogo, gradoTemporal;


    public List<DIALOGOS> historia = new List<DIALOGOS>();

    public string pregunta;

    private void Start()
    {
        gradoTemporal = -1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GLOBAL_Dialogos.enDialogo && GLOBAL_Dialogos.dialogosCientifica)
        {
            SiguienteTexto();
        }
        ActivarHistoria();
    }

    void ActivarHistoria()
    {
        if (GLOBAL_Dialogos.gradoCientifica != gradoTemporal && !GLOBAL_Dialogos.enDialogo && GLOBAL_Dialogos.dialogosCientifica)
        {
            dialogo = 0;
            gradoTemporal = GLOBAL_Dialogos.gradoCientifica;
            GLOBAL_Dialogos.enDialogo = true;
            canvas.SetActive(true);
            imajenFondo.SetActive(true);
            SiguienteTexto();
        }
    }

    void SiguienteTexto()
    {
        if (historia[GLOBAL_Dialogos.gradoCientifica].dialogos.Length > dialogo)
        {
            texto.text = historia[GLOBAL_Dialogos.gradoCientifica].dialogos[dialogo];
            dialogo++;
        }
        else if (GLOBAL_Dialogos.gradoCientifica == 7)
        {
            imajenFondo.SetActive(false);
            canvas.SetActive(false);
            GLOBAL_Dialogos.dialogosCientifica = false;
            GLOBAL_Dialogos.enDialogo = false;
        }
        else
            ActivaarOpciones();
    }

    void ActivaarOpciones()
    {
        texto.text = pregunta;
        opcines.SetActive(true);
    }

    public void OpcionElejida(int indice)
    {
        GLOBAL_Dialogos.gradoCientifica = indice;
        opcines.SetActive(false);
        GLOBAL_Dialogos.enDialogo = false;
    }
}
