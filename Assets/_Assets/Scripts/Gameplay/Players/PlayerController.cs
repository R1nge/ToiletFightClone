using System;
using _Assets.Scripts.Services;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Players
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : MonoBehaviour, IDamageable
    {
        private int _health;
        private CharacterMovement _characterMovement;
        private Transform _endPoint;
        [Inject] private PlayerInput _playerInput;
        [Inject] private PlayerUpgradeService _playerUpgradeService;
        public event Action<int, int> OnHealthChanged;
        public event Action OnDeath;

        private void Awake() => _characterMovement = GetComponent<CharacterMovement>();

        private void Start()
        {
            _health = _playerUpgradeService.PlayerData.health;
            OnHealthChanged?.Invoke(_health, _playerUpgradeService.PlayerData.health);
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

        public void TakeDamage(int damage)
        {
            if (_playerInput.IsBlocking && !_playerInput.IsAttacking)
            {
                Debug.Log("Can't take damage while blocking", this);
                return;
            }

            if (damage <= 0)
            {
                Debug.LogError("Damage must be greater than 0", this);
                return;
            }

            _health = Mathf.Clamp(_health - damage, 0, _playerUpgradeService.PlayerData.health);
            OnHealthChanged?.Invoke(_health, _playerUpgradeService.PlayerData.health);

            if (_health == 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}