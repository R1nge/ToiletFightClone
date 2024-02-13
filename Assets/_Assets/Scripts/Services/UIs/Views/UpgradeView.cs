using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private Button buyButton;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private TextMeshProUGUI costText;
        public event Action OnBuy;

        private void Awake() => buyButton.onClick.AddListener(Buy);

        private void Buy() => OnBuy?.Invoke();

        public void UpdateLevel(int level) => levelText.text = $"{level} LVL";

        public void UpdateAmount(int amount) => amountText.text = amount.ToString();

        public void UpdateCost(int cost) => costText.text = cost.ToString();

        private void OnDestroy() => buyButton.onClick.RemoveAllListeners();
    }
}