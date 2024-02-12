﻿using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class MainState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly UIStateMachine _uiStateMachine;
        private readonly PlayerSpawner _playerSpawner;

        public MainState(GameStateMachine stateMachine, UIStateMachine uiStateMachine, PlayerSpawner playerSpawner)
        {
            _stateMachine = stateMachine;
            _uiStateMachine = uiStateMachine;
            _playerSpawner = playerSpawner;
        }

        public void Enter()
        {
            _uiStateMachine.SwitchState(UIStateType.Main);
            var player = _playerSpawner.Spawn();
        }

        public void Exit() { }
    }
}