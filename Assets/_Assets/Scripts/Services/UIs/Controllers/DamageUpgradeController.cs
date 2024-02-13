using _Assets.Scripts.Services.UIs.Views;
using _Assets.Scripts.Services.Wallets;
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
            
            
            upgradeView.UpdateAmount(1);
            upgradeView.UpdateCost(1);
            upgradeView.UpdateLevel(1);
        }

        private void TryBuyDamage()
        {
            if (_playerUpgradeService.TryUpgradeDamage(_wallet.walletData.money, 0))
            {
                upgradeView.UpdateAmount(10);
                upgradeView.UpdateCost(10);
                upgradeView.UpdateLevel(10);
            }
        }
    }
}