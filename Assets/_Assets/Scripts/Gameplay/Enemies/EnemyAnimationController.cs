using System;
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
            _enemyAttackController.OnAttack += AttackAnimation;
        }

        private void AttackAnimation()
        {
            animator.SetBool(IsAttacking, true);
        }
    }
}