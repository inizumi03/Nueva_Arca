using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gestordedialogo : MonoBehaviour
{
    public GameObject canvas, opcinesSimples, opcionesAlberto;
    public TextMeshProUGUI texto, opcion1, opcion2;
    int estado, indiceTemporal;

    public List<DIALOGOS> textoAda = new List<DIALOGOS>();
    public List<DIALOGOS> textoDex = new List<DIALOGOS>();
    public List<DIALOGOS> dialogosEspeciales = new List<DIALOGOS>();
    public List<DIALOGOS> historia = new List<DIALOGOS>();
    public List<DIALOGOS> posmortem = new List<DIALOGOS>();

    public List<DIALOGOS> opciones = new List<DIALOGOS>();


    void Start()
    {
        GLOBAL_Dialogos.puzzleResuelto = false;
        GLOBAL_Dialogos.gradoDialogoAda = new int[3];
        GLOBAL_Dialogos.gradoDialogoDex = new int[3];
        AbrirCerrarTexto();
        Movimiento.LlamarAAda += DialogosDeAda;
        Movimiento.LlamarADex += DialogosDeDex;
        AreaDeAccion.llamar += DialogoEvento;
        GLOBAL_Dialogos.indiseGeneralHistoria = 0;
        GLOBAL_Dialogos.gradoHistoria = 0;
        indiceTemporal = -1;
        GLOBAL_Dialogos.indicePosmortem = 0;
        GLOBAL_Dialogos.gradoDialogoEspecial = 0;
        GLOBAL_Dialogos.trajeObtenido = false;
        GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona] = 0;
        if (GLOBAL_Dialogos.gradoPosmortem != 0)
            ActivarPosmortem();
        else
            ActivarHistoria();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GLOBAL_Dialogos.enDialogo && !GLOBAL_Dialogos.dialogosCientifica)
        {
            SiguienteTexto();
        }
        ActivarHistoria();
    }

    void AbrirCerrarTexto()
    {
        GLOBAL_Dialogos.enDialogo = false;
        canvas.SetActive(!canvas.activeSelf);
    }

    void DialogosDeAda()
    {
        AbrirCerrarTexto();
        GLOBAL_Dialogos.enDialogo = true;
        texto.text = textoAda[GLOBAL_Dialogos.sona].dialogos[GLOBAL_Dialogos.gradoDialogoAda[GLOBAL_Dialogos.sona]];
        estado = 0;
    }

    void DialogosDeDex()
    {
        AbrirCerrarTexto();
        GLOBAL_Dialogos.enDialogo = true;
        texto.text = textoDex[GLOBAL_Dialogos.sona].dialogos[GLOBAL_Dialogos.gradoDialogoDex[GLOBAL_Dialogos.sona]];
        estado = 0;
    }

    void DialogoEvento()
    {
        AbrirCerrarTexto();
        GLOBAL_Dialogos.enDialogo = true;
        texto.text = dialogosEspeciales[GLOBAL_Dialogos.sona].dialogos[GLOBAL_Dialogos.gradoDialogoEspecial];
        estado = 0;
        if (GLOBAL_Dialogos.sona == 0)
        {
            estado = 2;
        }
    }

    void SiguienteTexto()
    {
        if (estado == 0)
            AbrirCerrarTexto();
        else if (estado == 1)
        {
            if (historia[GLOBAL_Dialogos.indiseGeneralHistoria].dialogos.Length > GLOBAL_Dialogos.gradoHistoria)
            {
                texto.text = historia[GLOBAL_Dialogos.indiseGeneralHistoria].dialogos[GLOBAL_Dialogos.gradoHistoria];
                GLOBAL_Dialogos.gradoHistoria++;
            }
            else if (GLOBAL_Dialogos.indiseGeneralHistoria == 2)
            {
                ActivarOpciones(0);
            }
            else if (GLOBAL_Dialogos.indiseGeneralHistoria == 9)
            {
                ActivarOpciones(2);
            }
            else if (GLOBAL_Dialogos.indiseGeneralHistoria == 16)
            {
                ActivarOpciones(1);
            }
            else
            {
                AbrirCerrarTexto();

                if (GLOBAL_Dialogos.indiseGeneralHistoria == 3)
                    GLOBAL_Dialogos.indiseGeneralHistoria++;
            }
        }
        else if (estado == 2)
        {
            if (GLOBAL_Dialogos.gradoDialogoEspecial == 1 && GLOBAL_Dialogos.sona == 0)
            {
                if (GLOBAL_Dialogos.gradoPosmortem == 0) GLOBAL_Dialogos.gradoPosmortem = 1;

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            AbrirCerrarTexto();
            if (GLOBAL_Dialogos.sona == 0 && GLOBAL_Dialogos.gradoDialogoEspecial == 0)
            {
                GLOBAL_Dialogos.gradoDialogoEspecial = 1;
                DialogoEvento();
            }
        }
        else if (estado == 3)
        {
            if (posmortem[GLOBAL_Dialogos.gradoPosmortem].dialogos.Length > GLOBAL_Dialogos.indicePosmortem)
            {
                texto.text = posmortem[GLOBAL_Dialogos.gradoPosmortem].dialogos[GLOBAL_Dialogos.indicePosmortem];
                GLOBAL_Dialogos.indicePosmortem++;
            }
            else
                AbrirCerrarTexto();
        }
    }

    void ActivarHistoria()
    {
        if (GLOBAL_Dialogos.indiseGeneralHistoria != indiceTemporal && !GLOBAL_Dialogos.enDialogo)
        {
            GLOBAL_Dialogos.gradoHistoria = 0;
            indiceTemporal = GLOBAL_Dialogos.indiseGeneralHistoria;
            AbrirCerrarTexto();
            GLOBAL_Dialogos.enDialogo = true;
            estado = 1;
            SiguienteTexto();
        }
    }

    void ActivarPosmortem()
    {
        GLOBAL_Dialogos.gradoPosmortem--;
        GLOBAL_Dialogos.indiseGeneralHistoria = 0;
        indiceTemporal = GLOBAL_Dialogos.indiseGeneralHistoria;
        AbrirCerrarTexto();
        GLOBAL_Dialogos.enDialogo = true;
        estado = 3;
        SiguienteTexto();
    }

    public void OpcionMultipleHistoria(int indice)
    {
        GLOBAL_Dialogos.indiseGeneralHistoria += indice;
        AbrirCerrarTexto();
        opcinesSimples.SetActive(false);
        opcionesAlberto.SetActive(false);
    }

    void ActivarOpciones(int indice)
    {
        if (indice == 2)
            opcionesAlberto.SetActive(true);
        else
        {
            opcion1.text = opciones[indice].dialogos[0];
            opcion2.text = opciones[indice].dialogos[1];

            opcinesSimples.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        Movimiento.LlamarAAda -= DialogosDeAda;
        Movimiento.LlamarADex -= DialogosDeDex;
        AreaDeAccion.llamar -= DialogoEvento;
    }
}
