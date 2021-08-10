using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] playerObject _playerObject;

    private void playerMove(Collision col)
    {
      
        col.transform.position =_playerObject._points[Random.RandomRange(1, _playerObject._points.Length)];
        col.rigidbody.velocity = (Vector3.zero);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            playerMove(collision);
        }
        if ( collision.gameObject.tag == "agent")
        {
            collision.gameObject.GetComponent<agentScript>().ajan.enabled = false;
            playerMove(collision);
            collision.gameObject.GetComponent<agentScript>().wakeUp();
        }
    }
}
