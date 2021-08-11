using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] PlayerObject playerObject;
    private void playerMove(Collision col)
    {
        col.transform.position =playerObject.Points[Random.Range(1, playerObject.Points.Length)];
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
            collision.gameObject.GetComponent<AgentScript>().Ajan.enabled = false;
            playerMove(collision);
            collision.gameObject.GetComponent<AgentScript>().wakeUp();
        }
    }
}
