using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UIMainState : IUIState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UIMainState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateMainUI();

        public void Exit() => Object.Destroy(_ui);
    }
}