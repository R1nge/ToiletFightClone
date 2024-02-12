using UnityEngine;
using UnityEngine.AI;

namespace _Assets.Scripts.Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;

        public void SetDestination(Vector3 destination)
        {
            agent.destination = destination;
        }
    }
}