using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Cambiacolor : MonoBehaviour
{
    public List<Color> colores = new List<Color>();
    Color mColor;
    public GameObject balaPrefab, jugador;
    float temp;
    public float tempMax;

    void Start()
    {
        mColor = colores[Random.Range(0, colores.Count)];

        GetComponent<Renderer>().material.color = mColor;

        Pilares.BorrarColores += EliminarColor;
    }

    void Update()
    {
        transform.LookAt(jugador.transform.position);
        Temporizador();

        if (transform.position.y < -2)
            Destroy(gameObject);
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, transform.position, transform.rotation);

        Renderer balaRender = bala.GetComponent<Renderer>();

        balaRender.material.color = mColor;

        if (colores.Count > 0)
            mColor = colores[Random.Range(0, colores.Count)];

        GetComponent<Renderer>().material.color = mColor;
    }
    void Temporizador()
    {
        if (temp < tempMax)
            temp += Time.deltaTime;
        else
        {
            temp = 0;
            Disparar();
        }
    }

    void EliminarColor(Color pColor)
    {
        for (int i = 0; i < colores.Count; i++)
        {
            if (colores[i] == pColor)
            {
                colores.RemoveAt(i);
                tempMax -= 1;
            }
        }
    }
}
