using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Players
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private Transform _endPoint;
        [Inject] private PlayerInput _playerInput;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }

        public void SetEndPoint(Transform endPoint)
        {
            _endPoint = endPoint;
            _characterMovement.SetDestination(_endPoint.position);
        }

        //TODO: attack animation
        //TODO: block animation
    }
}