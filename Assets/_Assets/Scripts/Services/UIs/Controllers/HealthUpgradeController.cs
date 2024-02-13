using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class HealthUpgradeController : MonoBehaviour
    {
        [SerializeField] private UpgradeView upgradeView;
        [Inject] private Wallet _wallet;
        [Inject] private PlayerUpgradeService _playerUpgradeService;

        private void Start()
        {
            upgradeView.OnBuy += TryBuyHealth;
            
            upgradeView.UpdateAmount(_playerUpgradeService.PlayerData.health);
            upgradeView.UpdateCost(10);
            upgradeView.UpdateLevel(1);
        }

        private void TryBuyHealth()
        {
            if (_playerUpgradeService.TryUpgradeDamage(_wallet.walletData.money, 0))
            {
                upgradeView.UpdateAmount(_playerUpgradeService.PlayerData.health);
                upgradeView.UpdateCost(10);
                upgradeView.UpdateLevel(10);
            }
        }
    }
}