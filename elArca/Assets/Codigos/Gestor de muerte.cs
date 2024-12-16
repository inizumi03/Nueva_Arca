using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordemuerte : MonoBehaviour
{
    public TextMeshProUGUI contador;

    public float tempMax;
    float temp;

    void Start()
    {
        
    }

    void Update()
    {
        if (Colicion.equibocado)
        {
            GLOBAL_Dialogos.indiseGeneralHistoria = 14;
        }
        temporizador();
        contador.text = (tempMax - temp).ToString("F0");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            GLOBAL_Dialogos.gradoPosmortem = 2;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void temporizador()
    {
        if (!GLOBAL_Dialogos.enDialogo)
        {
            if (temp < tempMax) temp += Time.deltaTime;
            else
            {
                if (GLOBAL_Dialogos.gradoPosmortem == 0) GLOBAL_Dialogos.gradoPosmortem = 1;

                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
