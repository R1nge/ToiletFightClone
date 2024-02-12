using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Assets.Scripts.Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            //For some reason, it doesn't work if attached to prefab
            //And I don't have time to find out why
            _agent = gameObject.AddComponent<NavMeshAgent>();
        }

        public void SetDestination(Vector3 destination)
        {
            _agent.destination = destination;
        }
    }
}