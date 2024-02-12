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
            Debug.LogWarning("Open settings menu");
        }

        private void OpenShop()
        {
            Debug.LogWarning("Open shop");
        }

        private void OpenAgents()
        {
            Debug.LogWarning("Open agents");
        }

        public void UpdateWallet(int money) => walletText.text = money.ToString();
    }
}