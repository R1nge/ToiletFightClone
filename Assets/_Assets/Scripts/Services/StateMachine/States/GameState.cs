using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;

        public GameState(GameStateMachine gameStateMachine, UIStateMachine uiStateMachine, PlayerSpawner playerSpawner)
        {
            _gameStateMachine = gameStateMachine;
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
        }
        
        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.Game);
            var player = _playerSpawner.Spawn();
        }

        public void Exit()
        {
        }
    }
}