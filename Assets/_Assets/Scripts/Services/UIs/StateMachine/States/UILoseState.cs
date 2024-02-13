using UnityEngine;

namespace _Assets.Scripts.Services.UIs.StateMachine.States
{
    public class UILoseState : IUIState
    {
        private readonly UIFactory _uiFactory;
        private GameObject _ui;

        public UILoseState(UIFactory uiFactory) => _uiFactory = uiFactory;

        public void Enter() => _ui = _uiFactory.CreateLoseUI();

        public void Exit() => Object.Destroy(_ui);
    }
}