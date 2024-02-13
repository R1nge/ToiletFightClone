using System;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private MyButton attackButton;
        [SerializeField] private MyButton blockButton;

        public event Action OnStartAttacking;
        public event Action OnStopAttacking;
        public event Action OnStartBlocking;
        public event Action OnStopBlocking;

        private void Awake()
        {
            attackButton.OnButtonDown += StartAttacking;
            attackButton.OnButtonUp += StopAttacking;
            blockButton.OnButtonDown += StartBlocking;
            blockButton.OnButtonUp += StopBlocking;
        }

        private void StartBlocking() => OnStartBlocking?.Invoke();

        private void StopBlocking() => OnStopBlocking?.Invoke();

        private void StopAttacking() => OnStopAttacking?.Invoke();

        private void StartAttacking() => OnStartAttacking?.Invoke();

        private void OnDestroy()
        {
            attackButton.OnButtonDown -= StartAttacking;
            attackButton.OnButtonUp -= StopAttacking;
            blockButton.OnButtonDown -= StartBlocking;
            blockButton.OnButtonUp -= StopBlocking;
        }
    }
}