using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.forward * velocidad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        Destroy(gameObject);
    }
}
