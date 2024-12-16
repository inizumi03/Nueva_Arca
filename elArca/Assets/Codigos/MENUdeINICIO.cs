using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUdeINICIO : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que quieres cambiar

    // Método para iniciar el juego
    public void IniciarJuego()
    {
        SceneManager.LoadScene(nombreEscena); // Cambia a la escena especificada
    }

    // Método para salir del juego
    public void SalirDelJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Solo para el modo de edición en Unity Editor
#else
            Application.Quit(); // Cierra la aplicación en modo de ejecución
#endif
    }
}
