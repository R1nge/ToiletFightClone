using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainStatesFactory : IStateFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;

        private MainStatesFactory(UIStateMachine uiStateMachine, PlayerSpawner playerSpawner)
        {
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
        }
        
        public IGameState CreateState(GameStateMachine gameStateMachine)
        {
            return new MainState(gameStateMachine, _uiStateMachine, _playerSpawner);
        }
    }
}