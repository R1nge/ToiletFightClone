using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIWinState : IUIState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UIWinState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateWinUI();

        public void Exit() => Object.Destroy(_ui);
    }
}