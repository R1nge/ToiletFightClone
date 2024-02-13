using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class LostController : MonoBehaviour
    {
        [SerializeField] private LostView lostView;
        [Inject] private GameSceneService _gameSceneService;
        
        private void Start()
        {
            lostView.OnMain += ReturnToMain;
            lostView.OnRestart += Restart;
        }

        private void ReturnToMain() => _gameSceneService.LoadMain();

        private void Restart() => _gameSceneService.LoadLastGameLevel();

        private void OnDestroy()
        {
            lostView.OnMain -= ReturnToMain;
            lostView.OnRestart -= Restart;
        }
    }
}