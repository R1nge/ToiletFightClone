using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class DamageUpgradeController : MonoBehaviour
    {
        [SerializeField] private UpgradeView upgradeView;
        [Inject] private Wallet _wallet;
        [Inject] private PlayerUpgradeService _playerUpgradeService;

        private void Start()
        {
            upgradeView.OnBuy += TryBuyDamage;
            
            
            upgradeView.UpdateAmount(_playerUpgradeService.PlayerData.damage);
            upgradeView.UpdateCost(10);
            upgradeView.UpdateLevel(1);
        }

        private void TryBuyDamage()
        {
            if (_playerUpgradeService.TryUpgradeDamage(_wallet.walletData.money, 0))
            {
                upgradeView.UpdateAmount(_playerUpgradeService.PlayerData.damage);
                upgradeView.UpdateCost(10);
                upgradeView.UpdateLevel(10);
            }
        }
    }
}