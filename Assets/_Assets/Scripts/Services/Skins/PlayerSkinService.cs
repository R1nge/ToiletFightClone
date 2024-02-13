using System;
using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Services.Skins
{
    public class PlayerSkinService
    {
        private readonly ConfigProvider _configProvider;
        private int _currentSkinIndex;

        private PlayerSkinService(ConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public void SelectSkin(int index)
        {
            if (IndexOutOfRange(index))
            {
                return;
            }
            
            _currentSkinIndex = index;
        }

        public GameObject GetGameplay() => _configProvider.SkinsConfig.Gameplay;

        public GameObject GetSkin()
        {
            if (IndexOutOfRange(_currentSkinIndex))
            {
                return null;
            }
            
            return _configProvider.SkinsConfig.Prefabs[_currentSkinIndex];
        }

        private bool IndexOutOfRange(int index)
        {
            if (index >= _configProvider.SkinsConfig.Prefabs.Length)
            {
                Debug.LogError($"Player skin service: Index is out of range; Index: {index}, Length: {_configProvider.SkinsConfig.Prefabs.Length}");
                return true;
            }

            return false;
        }
        
        [Serializable]
        public struct PlayerSkinData
        {
            public bool unlocked;
            public int price;
        }
    }
}