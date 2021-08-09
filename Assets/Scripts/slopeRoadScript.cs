using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slopeRoadScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.rigidbody.GetComponent<PlayerController>().surtunme = 2;
        if (collision.gameObject.tag == "agent")
            collision.gameObject.GetComponent<agentScript>().ajan.speed /=2 ;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
            collision.rigidbody.GetComponent<PlayerController>().surtunme = 1;
        if (collision.gameObject.tag == "agent")
            collision.gameObject.GetComponent<agentScript>().ajan.speed*=2;
    }
}
