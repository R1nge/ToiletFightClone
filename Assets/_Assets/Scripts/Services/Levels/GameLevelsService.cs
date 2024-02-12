using System;
using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Services.Levels
{
    public class GameLevelsService
    {
        private readonly ConfigProvider _configProvider;
        private GameProgressData _gameProgressData;

        private GameLevelsService(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public string GetLastLevelName()
        {
            if (OutOfRange(_gameProgressData.lastLevelIndex))
            {
                return null;
            }

            return _configProvider.LevelsConfig.Levels[_gameProgressData.lastLevelIndex];
        }

        public void NextLevel()
        {
            if (OutOfRange(_gameProgressData.lastLevelIndex+ 1))
            {
                return;
            }

            _gameProgressData.lastLevelIndex++;
        }

        private bool OutOfRange(int index)
        {
            if (index >= _configProvider.LevelsConfig.Levels.Length)
            {
                Debug.LogError($"Game levels: index is out of range; Index: {index}; Length: {_configProvider.LevelsConfig.Levels.Length}");
                return true;
            }

            return false;
        }
        
        [Serializable]
        public struct GameProgressData
        {
            public int lastLevelIndex;

            public GameProgressData(int lastLevelIndex)
            {
                this.lastLevelIndex = lastLevelIndex;
            }
        }
    }
}