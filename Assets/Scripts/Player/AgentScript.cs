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

        public NavMeshAgent Agent { get { return _agent; } set { _agent = value; } }
        public Animator Anim { get { return _anim; } set { _anim = value; } }

        public Vector3 Finish { get => _finish; set => _finish = value; }
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