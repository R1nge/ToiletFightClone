using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class WinController : MonoBehaviour
    {
        [SerializeField] private WinView winView;
        [Inject] private GameSceneService _gameSceneService;

        private void Start() => winView.OnMainButtonClicked += ReturnToMainMenu;

        private void ReturnToMainMenu() => _gameSceneService.LoadMain();

        private void OnDestroy() => winView.OnMainButtonClicked -= ReturnToMainMenu;
    }
}