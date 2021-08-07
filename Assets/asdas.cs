using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdas : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.velocity = (Vector3.forward * 100);
    }
}
