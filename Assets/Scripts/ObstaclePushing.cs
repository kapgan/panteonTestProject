﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePushing : MonoBehaviour
{
    [SerializeField] float fx = 100;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "agent")
            collision.gameObject.GetComponent<agentScript>().ajan.enabled = false;
        if (collision.rigidbody)
        {
            Vector3 direction = (transform.position - collision.transform.position).normalized;
            collision.rigidbody.AddForce(direction * fx);
        }
        if (collision.gameObject.tag == "agent")
           collision.gameObject.GetComponent<agentScript>().wakeUp();
    }
}
