using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusibleInteraction : MonoBehaviour
{
    public GameObject panelCables;

    private void OnMouseDown()
    {
        if (panelCables != null)
        {
            panelCables.SetActive(true);
            Debug.Log("Canvas activado");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.LogWarning("PanelCables no está asignado.");
        }
    }
}
