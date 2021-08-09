using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class agentScript : MonoBehaviour
{
   
    Rigidbody rb;
    public NavMeshAgent ajan;

    Vector3 final=new Vector3(0,3,30);

    void Start()
    {
        ajan = transform.GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        wakeUp();
    }

    public  void wakeUp()
    {
        ajan.enabled =  true;
        ajan.SetDestination(final);
    }


}
