using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.UIs
{
    public class UIFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;
        
        public UIFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public GameObject CreateMainUI() => _objectResolver.Instantiate(_configProvider.UIConfig.MainUI);

        public GameObject CreateGameUI() => _objectResolver.Instantiate(_configProvider.UIConfig.GameUI);

        public GameObject CreateWinUI() => _objectResolver.Instantiate(_configProvider.UIConfig.WinUI);

        public GameObject CreateLoseUI() => _objectResolver.Instantiate(_configProvider.UIConfig.LoseUI);
    }
}