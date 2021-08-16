using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] StartObjectPoints startobjectPoints;
    private void playerMove(Collision col)
    {
        col.transform.position =startobjectPoints.Points[Random.Range(1, startobjectPoints.Points.Length)];
        col.rigidbody.velocity = (Vector3.zero);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playerMove(collision);
        }
        if ( collision.gameObject.tag == "Agent")
        {
            collision.gameObject.GetComponent<AgentScript>().Agent.enabled = false;
            playerMove(collision);
            collision.gameObject.GetComponent<AgentScript>().AgentWakeUp();
        }
    }
}
