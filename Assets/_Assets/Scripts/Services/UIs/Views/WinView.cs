using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class WinView : MonoBehaviour
    {
        [SerializeField] private Button mainButton;
        public event Action OnMainButtonClicked;

        private void Awake() => mainButton.onClick.AddListener(ReturnToMainMenu);

        private void ReturnToMainMenu() => OnMainButtonClicked?.Invoke();

        private void OnDestroy() => mainButton.onClick.RemoveAllListeners();
    }
}