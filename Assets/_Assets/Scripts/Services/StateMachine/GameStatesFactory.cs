using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerSpawner _playerSpawner;

        private GameStatesFactory(UIStateMachine uiStateMachine, PlayerFactory playerFactory, PlayerSpawner playerSpawner)
        {
            _uiStateMachine = uiStateMachine;
            _playerFactory = playerFactory;
            _playerSpawner = playerSpawner;
        }
        
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _uiStateMachine, _playerSpawner);
        }
    }
}