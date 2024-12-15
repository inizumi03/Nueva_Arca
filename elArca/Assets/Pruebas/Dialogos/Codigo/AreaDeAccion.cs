using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeAccion : MonoBehaviour
{
    public bool desactivarStay;

    public int indice;
    public bool guardia;

    public delegate void LlamarMensaje();
    static public event LlamarMensaje llamar;

    private void Start()
    {
        indice += 2;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!desactivarStay)
        {
            if (Input.GetKey(KeyCode.F) && !GLOBAL_Dialogos.enDialogo)
            {
                if (guardia)
                {
                    if (GLOBAL_Dialogos.trajeObtenido)
                        GLOBAL_Dialogos.gradoDialogoEspecial = 2;
                    else
                        GLOBAL_Dialogos.gradoDialogoEspecial = 0;

                    llamar.Invoke();
                }
                else
                    llamar.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (guardia && !GLOBAL_Dialogos.trajeObtenido)
        {
            GLOBAL_Dialogos.gradoDialogoEspecial = 0;
            llamar.Invoke();
        }
    }
}
