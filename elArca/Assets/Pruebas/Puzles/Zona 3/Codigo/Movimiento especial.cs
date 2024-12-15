using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Movimientoespecial : MonoBehaviour
{
    public TextMeshProUGUI text, opcion1, opcion2;
    public GameObject opciones, canvas, jugador;
    public string[] opcionesTxt;
    public string pregunta;
    static public bool enPuzle3;
    public GameObject[] filas;
    public int x, y;

    private void Start()
    {
        enPuzle3 = false;
        GLOBAL_Dialogos.sona = 3;
    }

    void Update()
    {
        if (enPuzle3 && !Colicion.equibocado)
        {
            Movimiento();
        }

        if (Colicion.superado && enPuzle3)
        {
            jugador.transform.position += Vector3.forward * 5;
            enPuzle3 = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!enPuzle3)
            {
                text.text = pregunta;
                opcion1.text = opcionesTxt[0];
                opcion2.text = opcionesTxt[1];
                opciones.SetActive(true);
                canvas.SetActive(true);
                GLOBAL_Dialogos.enDialogo = true;
            }
        }
    }

    public void Eleccion(int indice)
    {
        if (GLOBAL_Dialogos.sona == 3)
        {
            if (indice == 0)
            {
                enPuzle3 = true;
                Pocicionamiento();
            }
            else jugador.transform.position += Vector3.back * 5;

            GLOBAL_Dialogos.enDialogo = false;
            opciones.SetActive(false);
            canvas.SetActive(false);
        }
    }

    void Pocicionamiento()
    {
        jugador.transform.position = new Vector3(filas[y].transform.GetChild(x).transform.position.x, jugador.transform.position.y, filas[y].transform.GetChild(x).transform.position.z);
    }

    void Movimiento()
    {
        if (Input.GetKeyDown(KeyCode.W)) y++;
        else if (Input.GetKeyDown(KeyCode.S)) y--;
        else if (Input.GetKeyDown(KeyCode.D)) x++;
        else if (Input.GetKeyDown(KeyCode.A)) x--;

        if (x < 0) x = 0;
        if (y < 0) y = 0;
        if (y > filas.Length) y = filas.Length - 1;
        if (x > filas[y].transform.childCount) x = filas[y].transform.childCount - 1;

        Pocicionamiento();
    }
}
