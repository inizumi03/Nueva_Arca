using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComprobacionContraseña : MonoBehaviour
{
    public TextMeshProUGUI[] lector;
    public int[] respuestas;
    int[] valores;
    int indice;
    static public bool completo;

    void Start()
    {
        ComprobacionDeClock.Cargar += Comprobar;
        Reiniciar();
    }

    private void OnEnable()
    {
        Reiniciar();
    }

    void Comprobar(int valor)
    {
        if (valor > -1)
        {
            valores[indice] = valor;

            lector[indice].text = valor.ToString();

            indice++;
        }
        else if (valor == -2) gameObject.SetActive(false);
        else if (valor == -1) ComprobarContraseña();
    }

    void ComprobarContraseña()
    {
        if (valores[0] == respuestas[0] && valores[1] == respuestas[1] && valores[2] == respuestas[2])
        {
            completo = true;
            GLOBAL_Dialogos.dialogosCientifica = true;
            gameObject.SetActive(false);
        }
        else Reiniciar();
    }

    void Reiniciar()
    {
        foreach (TextMeshProUGUI txt in lector) txt.text = "-";
        indice = 0;
        completo = false;
        valores = new int[3];
    }
}
