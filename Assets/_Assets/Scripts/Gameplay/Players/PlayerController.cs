using UnityEngine;

namespace _Assets.Scripts.Gameplay.Players
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private Transform _endPoint;
        private bool _isBlocking;
        public bool IsBlocking => _isBlocking;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }

        public void SetEndPoint(Transform endPoint)
        {
            _endPoint = endPoint;
            _characterMovement.SetDestination(_endPoint.position);
        }

        public void Attack()
        {
            
        }

        public void StartBlocking()
        {
            _isBlocking = true;
        }

        public void StopBlocking()
        {
            _isBlocking = false;
        }
    }
}