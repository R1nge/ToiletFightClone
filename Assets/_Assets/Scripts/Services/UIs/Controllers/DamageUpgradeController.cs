using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class DamageUpgradeController : MonoBehaviour
    {
        [SerializeField] private UpgradeView upgradeView;
        [Inject] private PlayerUpgradeService _playerUpgradeService;

        private void Start()
        {
            upgradeView.UpdateAmount(1);
            upgradeView.UpdateCost(1);
            upgradeView.UpdateLevel(1);
        }
    }
}