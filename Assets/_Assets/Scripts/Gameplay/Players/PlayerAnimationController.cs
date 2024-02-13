using System;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Players
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        [Inject] private PlayerInput _playerInput;
        private static readonly int Attacking = Animator.StringToHash("Attacking");
        private static readonly int Blocking = Animator.StringToHash("Blocking");

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
            _playerInput.OnAttackStateChanged += OnAttackStateChanged;
            _playerInput.OnBlockStateChanged += OnBlockStateChanged;
        }

        private void OnAttackStateChanged(bool attack) => _animator.SetBool(Attacking, attack);

        private void OnBlockStateChanged(bool block) => _animator.SetBool(Blocking, block);

        private void OnDestroy()
        {
            _playerInput.OnAttackStateChanged -= OnAttackStateChanged;
            _playerInput.OnBlockStateChanged -= OnBlockStateChanged;
        }
    }
}