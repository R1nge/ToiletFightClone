using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class LostView : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainButton;
        public event Action OnRestart;
        public event Action OnMain;

        private void Start()
        {
            restartButton.onClick.AddListener(Restart);
            mainButton.onClick.AddListener(Main);
        }

        private void Main() => OnMain?.Invoke();

        private void Restart() => OnRestart?.Invoke();
    }
}