using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComprobacionDeClock : MonoBehaviour, IPointerClickHandler
{
    public int numero;

    public delegate void CargarNumero(int valor);
    static public CargarNumero Cargar;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) Cargar.Invoke(numero);
    }
}
