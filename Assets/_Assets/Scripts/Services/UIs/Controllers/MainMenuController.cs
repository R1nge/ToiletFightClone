using _Assets.Scripts.Services.UIs.Views;
using _Assets.Scripts.Services.Wallets;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MainMenuView view;
        [Inject] private Wallet _wallet;

        private void Start()
        {
            _wallet.OnMoneyChanged += UpdateWalletUI;
            UpdateWalletUI(_wallet.walletData.money);
        }

        private void UpdateWalletUI(int money) => view.UpdateWallet(money);

        public bool Spend(int amount) => _wallet.Spend(amount);

        private void OnDestroy() => _wallet.OnMoneyChanged -= UpdateWalletUI;
    }
}