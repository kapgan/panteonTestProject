using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] playerObject playerObject;

    
    public Transform finish;
    [SerializeField] float agentSpeed;
    Vector3[] points;
    GameObject agent;
    private void Start()
    {
        points = playerObject._points;
        agent = playerObject._agent;
        for (int i=1;i<points.Length-1; i++)
        {
            var a=Instantiate(agent, points[i],Quaternion.identity);
            a.GetComponent<agentScript>().ajan.speed = agentSpeed;
        }
    }
 
}
