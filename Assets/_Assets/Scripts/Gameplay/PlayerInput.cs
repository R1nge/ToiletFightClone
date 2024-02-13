using System;

namespace _Assets.Scripts.Gameplay
{
    public class PlayerInput
    {
        private bool _isAttacking;
        private bool _isBlocking;

        public bool IsBlocking
        {
            get => _isBlocking;
            set
            {
                if (_isBlocking != value)
                {
                    _isBlocking = value;
                    OnBlockStateChanged?.Invoke(value);
                }
            }
        }

        public bool IsAttacking
        {
            get => _isAttacking;
            set
            {
                if (_isAttacking != value)
                {
                    _isAttacking = value;
                    OnAttackStateChanged?.Invoke(value);
                }
            }
        }

        public event Action<bool> OnBlockStateChanged;
        public event Action<bool> OnAttackStateChanged;

        public void Reset()
        {
            IsAttacking = false;
            IsBlocking = false;
        }
    }
}