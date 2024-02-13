using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MainMenuView view;
        [Inject] private Wallet _wallet;
        [Inject] private GameSceneService _gameSceneService;

        private void Start()
        {
            _wallet.OnMoneyChanged += UpdateWalletUI;
            UpdateWalletUI(_wallet.walletData.money);

            view.OnPlay += Play;
        }

        private void Play() => _gameSceneService.LoadLastGameLevel();

        private void UpdateWalletUI(int money) => view.UpdateWallet(money);

        public bool Spend(int amount) => _wallet.Spend(amount);

        private void OnDestroy()
        {
            _wallet.OnMoneyChanged -= UpdateWalletUI;
            view.OnPlay -= Play;
        }
    }
}