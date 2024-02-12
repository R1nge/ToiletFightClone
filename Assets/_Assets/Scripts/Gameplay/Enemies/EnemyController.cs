using System;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    [RequireComponent(typeof(EnemyAttackController), typeof(CharacterMovement))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyData data;
        private Transform _player;
        private EnemyAttackController _enemyAttackController;
        private CharacterMovement _characterMovement;

        private void Awake()
        {
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
            public float detectRange;
            public float attackRange;
        }
    }
}