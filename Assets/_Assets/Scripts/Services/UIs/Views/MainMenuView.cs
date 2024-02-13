using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI walletText;
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button shopButton, agentsButton;

        public event Action OnPlay;
        public event Action OnSettings;
        public event Action OnShop;
        public event Action OnAgents;

        private void Start()
        {
            playButton.onClick.AddListener(Play);
            settingsButton.onClick.AddListener(OpenSettingsMenu);
            shopButton.onClick.AddListener(OpenShop);
            agentsButton.onClick.AddListener(OpenAgents);
        }

        private void Play()
        {
            OnPlay?.Invoke();
            Debug.LogWarning("Play");
        }

        private void OpenSettingsMenu()
        {
            OnSettings?.Invoke();
            Debug.LogWarning("Open settings menu");
        }

        private void OpenShop()
        {
            OnShop?.Invoke();
            Debug.LogWarning("Open shop");
        }

        private void OpenAgents()
        {
            OnAgents?.Invoke();
            Debug.LogWarning("Open agents");
        }

        public void UpdateWallet(int money) => walletText.text = money.ToString();
    }
}