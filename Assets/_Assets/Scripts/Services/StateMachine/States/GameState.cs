using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Players;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;
        private readonly EnemySpawner _enemySpawner;
        private readonly EndOfTheLevel _endOfTheLevel;

        public GameState(GameStateMachine gameStateMachine, UIStateMachine uiStateMachine, PlayerSpawner playerSpawner, EnemySpawner enemySpawner, EndOfTheLevel endOfTheLevel)
        {
            _gameStateMachine = gameStateMachine;
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _endOfTheLevel = endOfTheLevel;
        }
        
        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.Game);
            var player = _playerSpawner.SpawnGameplay();
            player.GetComponent<PlayerController>().SetEndPoint(_endOfTheLevel.EndPoint);
            _enemySpawner.SpawnNextWave(player.transform);
        }

        public void Exit()
        {
        }
    }
}