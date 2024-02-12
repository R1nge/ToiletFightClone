using System;
using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float attackDelay;
        private bool _canAttack = true;
        private YieldInstruction _cooldown;
        private Transform _player;

        public void SetPlayerReference(Transform player)
        {
            _player = player;
        }

        private void Start()
        {
            _cooldown = new WaitForSeconds(attackDelay);
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (_canAttack)
            {
                StartCoroutine(Cooldown_C());
            }
        }

        private IEnumerator Cooldown_C()
        {
            _canAttack = false;
            yield return _cooldown;
            _canAttack = true;
        }
    }
}