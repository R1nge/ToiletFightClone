using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory : IStateFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerSpawner _playerSpawner;
        private readonly EnemySpawner _enemySpawner;
        private readonly EndOfTheLevel _endOfTheLevel;
        private readonly PlayerInput _playerInput;

        private GameStatesFactory(UIStateMachine uiStateMachine, PlayerFactory playerFactory, PlayerSpawner playerSpawner, EnemySpawner enemySpawner, EndOfTheLevel endOfTheLevel, PlayerInput playerInput)
        {
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _playerSpawner = playerSpawner;
            _enemySpawner = enemySpawner;
            _endOfTheLevel = endOfTheLevel;
            _playerInput = playerInput;
        }

        public IGameState CreateState(GameStateMachine gameStateMachine)
        {
            return new GameState(gameStateMachine, _uiStateMachine, _playerSpawner, _enemySpawner, _endOfTheLevel, _playerInput);
        }
    }
}