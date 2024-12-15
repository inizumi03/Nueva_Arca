using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cambiar_Color : MonoBehaviour
{
    public Color color;

    private void Start()
    {
        GetComponent<Renderer>().material.color = color;
    }
}
