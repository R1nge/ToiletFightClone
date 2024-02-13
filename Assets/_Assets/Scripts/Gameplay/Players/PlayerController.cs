using System;
using System.Collections;
using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Enemies;
using _Assets.Scripts.Services;
using Cinemachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Players
{
    [RequireComponent(typeof(CharacterMovement))]
    public class PlayerController : MonoBehaviour, IDamageable
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
        [SerializeField] private SphereCollider detectRangeCollider;
        private readonly List<EnemyController> _enemies = new();
        private int _health;
        private CharacterMovement _characterMovement;
        private Transform _endPoint;
        [Inject] private PlayerInput _playerInput;
        [Inject] private PlayerUpgradeService _playerUpgradeService;

        private bool _canAttack = true;

        private YieldInstruction _attackCooldown;

        //Should have made a state machine for it
        public event Action<int, int> OnHealthChanged;
        public event Action OnDeath;

        private void Awake() => _characterMovement = GetComponent<CharacterMovement>();

        private void Start()
        {
            _attackCooldown = new WaitForSeconds(_playerUpgradeService.PlayerData.attackCooldown);
            detectRangeCollider.radius = _playerUpgradeService.PlayerData.detectRange;
            _health = _playerUpgradeService.PlayerData.health;
            OnHealthChanged?.Invoke(_health, _playerUpgradeService.PlayerData.health);
        }

        //TODO: damage controller
        private void Update()
        {
            if (_enemies.Count > 0)
            {
                SetCameraLookTarget(_enemies[0].transform);
                _characterMovement.SetDestination(_enemies[0].transform.position);

                if (_playerInput.IsAttacking && !_playerInput.IsBlocking)
                {
                    if (Vector3.Distance(transform.position, _enemies[0].transform.position) < _playerUpgradeService.PlayerData.attackRange)
                    {
                        if (_canAttack)
                        {
                            StartCoroutine(Cooldown_C());
                            _enemies[0].TakeDamage(_playerUpgradeService.PlayerData.damage);
                        }
                    }
                }
            }
            else
            {
                _characterMovement.SetDestination(_endPoint.position);
                SetCameraLookTarget(transform);
            }
        }

        private void SetCameraLookTarget(Transform target)
        {
            cinemachineVirtualCamera.LookAt = target;
        }

        private IEnumerator Cooldown_C()
        {
            _canAttack = false;
            yield return _attackCooldown;
            _canAttack = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyController enemy))
            {
                _enemies.Add(enemy);
                enemy.OnDeath += RemoveEnemy;
            }
        }

        private void RemoveEnemy(EnemyController enemy)
        {
            enemy.OnDeath -= RemoveEnemy;
            _enemies.Remove(enemy);
        }

        public void SetEndPoint(Transform endPoint)
        {
            _endPoint = endPoint;
            _characterMovement.SetDestination(_endPoint.position);
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