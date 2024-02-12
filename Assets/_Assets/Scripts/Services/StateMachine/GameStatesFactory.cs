using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;

        private GameStatesFactory(UIStateMachine uiStateMachine)
        {
            _uiStateMachine = uiStateMachine;
        }
        
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _uiStateMachine);
        }
    }
}