﻿using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIStateMachine _uiStateMachine;

        public GameState(GameStateMachine stateMachine, UIStateMachine uiStateMachine)
        {
            _stateMachine = stateMachine;
            _uiStateMachine = uiStateMachine;
        }

        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.Game);
        }

        public void Exit() { }
    }
}