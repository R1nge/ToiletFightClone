using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameView gameView;
        [Inject] private PlayerInput _playerInput;

        private void Awake()
        {
            gameView.OnStartAttacking += StartAttacking;
            gameView.OnStopAttacking += StopAttacking;
            gameView.OnStartBlocking += StartBlocking;
            gameView.OnStopBlocking += StopBlocking;
        }

        private void StartAttacking() => _playerInput.IsAttacking = true;

        private void StopAttacking() => _playerInput.IsAttacking = false;

        private void StartBlocking() => _playerInput.IsBlocking = true;

        private void StopBlocking() => _playerInput.IsBlocking = false;

        private void OnDestroy()
        {
            gameView.OnStartAttacking -= StartAttacking;
            gameView.OnStopAttacking -= StopAttacking;
            gameView.OnStartBlocking -= StartBlocking;
            gameView.OnStopBlocking -= StopBlocking;
        }
    }
}