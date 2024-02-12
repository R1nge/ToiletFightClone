using System;
using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    public class EnemyAttackController : MonoBehaviour
    {
        [SerializeField] private float attackDelay;
        private bool _canAttack = true;
        private YieldInstruction _cooldown;

        private void Awake()
        {
            _cooldown = new WaitForSeconds(attackDelay);
        }

        public void Attack()
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