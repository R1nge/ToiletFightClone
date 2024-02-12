using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Misc
{
    public class GameEntryPoint : MonoBehaviour
    {
        [Inject] private GameStateMachine _gameStateMachine;

        private void Start()
        {
            _gameStateMachine.AddState(GameStateType.Game);
            _gameStateMachine.SwitchState(GameStateType.Game);
        }
    }
}