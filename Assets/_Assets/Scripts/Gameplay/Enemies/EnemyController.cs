using System;
using _Assets.Scripts.Gameplay.Players;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    [RequireComponent(typeof(EnemyAttackController), typeof(CharacterMovement))]
    public class EnemyController : MonoBehaviour, IDamageable
    {
        [SerializeField] private EnemyData data;
        private PlayerController _player;
        private EnemyAttackController _enemyAttackController;
        private CharacterMovement _characterMovement;
        private bool _dead;
        public event Action<int, int> OnHealthChanged;
        public event Action<EnemyController> OnDeath;

        private void Awake()
        {
            _enemyAttackController = GetComponent<EnemyAttackController>();
            _characterMovement = GetComponent<CharacterMovement>();
        }

        private void Start()
        {
            data.health = data.maxHealth;
            OnHealthChanged?.Invoke(data.health, data.maxHealth);
        }

        public void SetPlayerReference(PlayerController player)
        {
            _player = player;
        }

        private void Update()
        {
            if (_dead) return;
            if (PlayerInAttackRange())
            {
                _enemyAttackController.Attack(_player, data.damage);
            }
            else if (PlayerInDetectRange())
            {
                _characterMovement.SetDestination(_player.transform.position);
            }
        }

        private bool PlayerInDetectRange()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= data.detectRange;
        }

        private bool PlayerInAttackRange()
        {
            return Vector3.Distance(transform.position, _player.transform.position) <= data.attackRange;
        }

        [Serializable]
        public struct EnemyData
        {
            public int maxHealth;
            public int health;
            public float detectRange;
            public float attackRange;
            public int damage;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                Debug.LogError("Damage must be greater than 0", this);
                return;
            }

            data.health = Mathf.Clamp(data.health - damage, 0, data.maxHealth);
            OnHealthChanged?.Invoke(data.health, data.maxHealth);

            if (data.health == 0)
            {
                OnDeath?.Invoke(this);
                _dead = true;
            }
        }
    }
}