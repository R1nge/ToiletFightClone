using System;
using System.Collections;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Enemies
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private EnemyAttackController _enemyAttackController;
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        private void Awake()
        {
            _enemyAttackController = GetComponent<EnemyAttackController>();
            _enemyAttackController.OnStartAttack += StartAttackAnimation;
        }

        private void StartAttackAnimation()
        {
            animator.SetTrigger(IsAttacking);
            StartCoroutine(Wait_C());
        }

        private IEnumerator Wait_C()
        {
            yield return new WaitForSeconds(0.1f);
            animator.ResetTrigger(IsAttacking);
        }

        private void OnDestroy()
        {
            _enemyAttackController.OnStartAttack -= StartAttackAnimation;
        }
    }
}