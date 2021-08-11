using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    public Animator Anim;
    public NavMeshAgent Ajan;

    private Rigidbody rb;
    private Vector3 final = new Vector3(0, 3, 30);

    void Start()
    {
        Anim = GetComponent<Animator>();
        Ajan = transform.GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        wakeUp();
    }

    public void wakeUp()
    {
        Ajan.enabled = true;
        Ajan.SetDestination(final);
    }


}
