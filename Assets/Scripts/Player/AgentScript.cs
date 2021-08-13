using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    public Animator Anim;
    public NavMeshAgent Ajan;

    private Rigidbody rb;
     Vector3 final = new Vector3(0, 3, 33);

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
