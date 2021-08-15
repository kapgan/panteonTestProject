using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;

    private Rigidbody _rb;
    private Vector3 final = new Vector3(0, 3, 33);

    public NavMeshAgent Agent { get { return _agent; } set { _agent = value; } }
    public Animator Anim { get { return _anim; } set { _anim = value; } }
    private void Awake()
    {
        _agent = transform.GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        AgentWakeUp();
    }
  
    public void AgentWakeUp()
    {
        _agent.enabled = true;
        _agent.SetDestination(final);
    }


}
