using TMPro;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private TextMeshProUGUI costText;

        public void UpdateLevel(int level) => levelText.text = $"{level} LVL";

        public void UpdateAmount(int amount) => amountText.text = amount.ToString();

        public void UpdateCost(int cost) => costText.text = cost.ToString();
    }
}