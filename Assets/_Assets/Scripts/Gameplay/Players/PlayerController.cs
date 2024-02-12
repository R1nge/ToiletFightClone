using UnityEngine;

namespace _Assets.Scripts.Gameplay.Players
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private Transform _target;
        private bool _isBlocking;
        public bool IsBlocking => _isBlocking;

        private void Start()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }

        public void SetTarget(Transform target)
        {
            _target = target;
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