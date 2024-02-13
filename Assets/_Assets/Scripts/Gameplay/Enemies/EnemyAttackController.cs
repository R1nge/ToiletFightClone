using System;
using System.Collections;
using _Assets.Scripts.Gameplay.Players;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    public class EnemyAttackController : MonoBehaviour
    {
        [SerializeField] private float attackDelay;
        public event Action OnStartAttack;
        private bool _canAttack = true;
        private YieldInstruction _cooldown;

        private void Awake()
        {
            _cooldown = new WaitForSeconds(attackDelay);
        }

        public void Attack(PlayerController playerController, int damage)
        {
            if (_canAttack)
            {
                OnStartAttack?.Invoke();
                playerController.TakeDamage(damage);
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