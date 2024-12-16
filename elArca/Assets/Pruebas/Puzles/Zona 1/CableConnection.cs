using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CableConnection : MonoBehaviour
{
    [SerializeField] private GameObject cableCorrecto; // El cable que debe conectarse aqu�
    private bool cableConectado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra es el cable correcto
        if (other.gameObject == cableCorrecto)
        {
            // Fija el cable en la posici�n del receptor
            CableDrag cable = other.GetComponent<CableDrag>();
            if (cable != null)
            {
                cable.isConnected = true; // Marca el cable como conectado
                other.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; // Fija la posici�n
                cableConectado = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Si el cable sale del receptor, marca como desconectado
        if (other.gameObject == cableCorrecto)
        {
            CableDrag cable = other.GetComponent<CableDrag>();
            if (cable != null)
            {
                cable.isConnected = false;
                cableConectado = false;
            }
        }
    }

    public bool EstaConectado()
    {
        return cableConectado; // Devuelve si el receptor est� conectado correctamente
    }
}
