using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay.Players
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [Inject] private PlayerInput _playerInput;
        private static readonly int Attacking = Animator.StringToHash("Attacking");
        private static readonly int Blocking = Animator.StringToHash("Blocking");

        private void Start()
        {
            _playerInput.OnAttackStateChanged += OnAttackStateChanged;
            _playerInput.OnBlockStateChanged += OnBlockStateChanged;
        }

        private void OnAttackStateChanged(bool attack)
        {
            animator.SetBool(Attacking, attack);
        }

        private void OnBlockStateChanged(bool block)
        {
            animator.SetBool(Blocking, block);
        }

        private void OnDestroy()
        {
            _playerInput.OnAttackStateChanged -= OnAttackStateChanged;
            _playerInput.OnBlockStateChanged -= OnBlockStateChanged;
        }
    }
}