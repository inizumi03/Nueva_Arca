using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarpuzzle : MonoBehaviour
{
    public GameObject imajen;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.F) && !GLOBAL_Dialogos.puzzleResuelto)
        {
            imajen.SetActive(true);
        }
    }
}
