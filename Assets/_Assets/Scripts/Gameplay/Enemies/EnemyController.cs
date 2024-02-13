using System;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    [RequireComponent(typeof(EnemyAttackController), typeof(CharacterMovement))]
    public class EnemyController : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyData data;
        private Transform _player;
        private EnemyAttackController _enemyAttackController;
        private CharacterMovement _characterMovement;
        public event Action<int> OnHealthChanged;
        public event Action OnDeath;

        private void Awake()
        {
            data.health = data.maxHealth;
            _enemyAttackController = GetComponent<EnemyAttackController>();
            _characterMovement = GetComponent<CharacterMovement>();
        }

        public void SetPlayerReference(Transform player)
        {
            _player = player;
        }

        private void Update()
        {
            if (PlayerInDetectRange())
            {
                _characterMovement.SetDestination(_player.position);
            }
            else if (PlayerInAttackRange())
            {
                _enemyAttackController.Attack();
            }
        }

        private bool PlayerInDetectRange()
        {
            return Vector3.Distance(transform.position, _player.position) <= data.detectRange;
        }

        private bool PlayerInAttackRange()
        {
            return Vector3.Distance(transform.position, _player.position) <= data.attackRange;
        }

        [Serializable]
        public struct EnemyData
        {
            public int maxHealth;
            public int health;
            public float detectRange;
            public float attackRange;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                Debug.LogError("Damage must be greater than 0", this);
                return;
            }

            data.health = Mathf.Clamp(data.health - damage, 0, data.maxHealth);
            OnHealthChanged?.Invoke(data.health);

            if (data.health == 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}