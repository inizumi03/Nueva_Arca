using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Pruebas : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] imajenes, posiciones;
    int pocicion, pocicionActual, correcto;
    float tempo;

    private void Start()
    {
        correcto = 0;
        Actualizar();
    }

    private void Update()
    {
        if (correcto < 4)
        {
            Movimiento();
        }
        else
        {
            Temporizador();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Vector2 clickPosition = eventData.position;

            RectTransform rectTransform = GetComponent<RectTransform>();
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, clickPosition, eventData.pressEventCamera, out localPoint);

            if (localPoint.x > 0)
            {
                if (localPoint.y > 0) pocicion = 1;
                else pocicion = 3;
            }
            else
            {
                if (localPoint.y > 0) pocicion = 0;
                else pocicion = 2;
            }

            pocicionActual = pocicion;
        }
    }

    void Movimiento()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pocicion < 3) pocicion++;
            else pocicion = 0;

            CambiarOrden(imajenes, pocicionActual, pocicion);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pocicion > 0) pocicion--;
            else pocicion = 3;

            CambiarOrden(imajenes, pocicionActual, pocicion);
        }
    }

    void Actualizar()
    {
        for (int i = 0; i < imajenes.Length; i++)
        {
            imajenes[i].transform.position = posiciones[i].transform.position;
        }
    }

    void CambiarOrden(GameObject[] array, int indice1, int indice2)
    {
        GameObject tem = array[indice1];
        array[indice1] = array[indice2];
        array[indice2] = tem;

        pocicionActual = indice2;
        Actualizar();
        Comprobacion();
    }

    void Comprobacion()
    {
        for (int i = 0; i < imajenes.Length; i++)
        {
            if (i == int.Parse(imajenes[i].name)) correcto++;
            else correcto = 0;
        }
    }

    void Temporizador()
    {
        if (tempo < 5) tempo += Time.deltaTime;
        else gameObject.SetActive(false);
    }
}