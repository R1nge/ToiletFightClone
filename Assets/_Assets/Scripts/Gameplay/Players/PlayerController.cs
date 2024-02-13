using System;
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

        private void Start()
        {
            _playerInput.OnAttackStateChanged += AttackStateChanged;
            _playerInput.OnBlockStateChanged += BlockStateChanged;
        }

        private void BlockStateChanged(bool block)
        {
            Debug.Log($"Block state changed {block}");
        }

        private void AttackStateChanged(bool attack)
        {
            Debug.Log($"Attack state changed {attack}");
        }

        public void SetEndPoint(Transform endPoint)
        {
            _endPoint = endPoint;
            _characterMovement.SetDestination(_endPoint.position);
        }

        private void OnDestroy()
        {
            _playerInput.OnAttackStateChanged -= AttackStateChanged;
            _playerInput.OnBlockStateChanged -= BlockStateChanged;
        }

        //TODO: attack animation
        //TODO: block animation
    }
}