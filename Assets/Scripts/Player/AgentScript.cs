using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PanteonGames
{
    public class AgentScript : MonoBehaviour
    {
        private Animator _anim;
        private NavMeshAgent _agent;
        private Rigidbody _agentRigidBody;
        private Vector3 _finish;


        public Vector3 Finish { get => _finish; set => _finish = value; }
        public Animator Anim { get => _anim; set => _anim = value; }
        public NavMeshAgent Agent { get => _agent; set => _agent = value; }

        private void Awake()
        {
            _agent = transform.GetComponent<NavMeshAgent>();
        }
        void Start()
        {
            _anim = GetComponent<Animator>();
            _agentRigidBody = GetComponent<Rigidbody>();
            AgentWakeUp();
        }
        public void AgentWakeUp()
        {
            _agent.enabled = true;
            _agent.SetDestination(_finish);
        }

    }
}