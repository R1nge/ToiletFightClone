using _Assets.Scripts.Services.UIs.StateMachine.States;

namespace _Assets.Scripts.Services.UIs.StateMachine
{
    public class UIStatesFactory
    {
        private readonly UIFactory _uiFactory;
        
        private UIStatesFactory(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public IUIState CreateMainState(UIStateMachine uiStateMachine)
        {
            return new UIMainState(_uiFactory);
        }

        public IUIState CreateGameState(UIStateMachine uiStateMachine)
        {
            return new UIGameState(_uiFactory);
        }

        public IUIState CreateWinState(UIStateMachine uiStateMachine)
        {
            return new UIWinState(_uiFactory);
        }

        public IUIState CreateLoseState(UIStateMachine uiStateMachine)
        {
            return new UILoseState(_uiFactory);
        }
    }
}