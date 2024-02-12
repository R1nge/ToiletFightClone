using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStateMachine
    {
        private readonly IStateFactory _statesFactory;
        private readonly Dictionary<GameStateType, IGameState> _states = new();
        private IGameState _currentGameState;
        private GameStateType _currentGameStateType;

        public GameStateMachine(IStateFactory statesFactory) => _statesFactory = statesFactory;

        public void AddState(GameStateType gameStateType)
        {
            _states.TryAdd(gameStateType, _statesFactory.CreateState(this));
        }

        public void SwitchState(GameStateType gameStateType)
        {
            if (_currentGameStateType == gameStateType)
            {
                Debug.LogError($"Trying to switch to the same state {gameStateType}");
                return;
            }

            _currentGameState?.Exit();
            _currentGameState = _states[gameStateType];
            _currentGameStateType = gameStateType;
            _currentGameState.Enter();
        }
    }
}