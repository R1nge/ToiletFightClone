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

        public event Action OnPlayEvent;
        public event Action OnSettingEvent;
        public event Action OnShopEvent;
        public event Action OnAgentsEvent;

        private void Start()
        {
            playButton.onClick.AddListener(Play);
            settingsButton.onClick.AddListener(OpenSettingsMenu);
            shopButton.onClick.AddListener(OpenShop);
            agentsButton.onClick.AddListener(OpenAgents);
        }

        private void Play()
        {
            OnPlayEvent?.Invoke();
            Debug.LogWarning("Play");
        }

        private void OpenSettingsMenu()
        {
            OnSettingEvent?.Invoke();
            Debug.LogWarning("Open settings menu");
        }

        private void OpenShop()
        {
            OnShopEvent?.Invoke();
            Debug.LogWarning("Open shop");
        }

        private void OpenAgents()
        {
            OnAgentsEvent?.Invoke();
            Debug.LogWarning("Open agents");
        }

        public void UpdateWallet(int money) => walletText.text = money.ToString();
    }
}