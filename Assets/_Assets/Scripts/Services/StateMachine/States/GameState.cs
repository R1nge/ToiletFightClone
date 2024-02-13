using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Players;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.UIs.StateMachine;
using Cinemachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;
        private readonly EnemySpawner _enemySpawner;
        private readonly EndOfTheLevel _endOfTheLevel;
        private readonly PlayerInput _playerInput;

        public GameState(GameStateMachine gameStateMachine, UIStateMachine uiStateMachine, PlayerSpawner playerSpawner, EnemySpawner enemySpawner, EndOfTheLevel endOfTheLevel, PlayerInput playerInput)
        {
            _gameStateMachine = gameStateMachine;
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _endOfTheLevel = endOfTheLevel;
            _playerInput = playerInput;
        }
        
        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.Game);
            var player = _playerSpawner.SpawnGameplay();
            var playerController = player.GetComponent<PlayerController>();
            playerController.SetEndPoint(_endOfTheLevel.EndPoint);
            _enemySpawner.SpawnNextWave(playerController);
        }

        public void Exit()
        {
            _playerInput.Reset();
        }
    }
}