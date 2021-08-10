using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent ajan;

    private Rigidbody rb;
    private Vector3 final = new Vector3(0, 3, 30);

    void Start()
    {
        anim = GetComponent<Animator>();
        ajan = transform.GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        wakeUp();
    }

    public void wakeUp()
    {
        ajan.enabled = true;
        ajan.SetDestination(final);
    }


}
