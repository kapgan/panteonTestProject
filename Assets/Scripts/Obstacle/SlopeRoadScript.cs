using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeRoadScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.rigidbody.GetComponent<PlayerController>().Friction = 2;
        if (collision.gameObject.tag == "Agent")
            collision.gameObject.GetComponent<AgentScript>().Agent.speed /=2 ;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
            collision.rigidbody.GetComponent<PlayerController>().Friction = 1;
        if (collision.gameObject.tag == "Agent")
            collision.gameObject.GetComponent<AgentScript>().Agent.speed*=2;
    }
}
