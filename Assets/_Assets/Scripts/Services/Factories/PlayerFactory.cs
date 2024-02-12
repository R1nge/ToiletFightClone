using _Assets.Scripts.Services.Skins;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly PlayerSkinService _playerSkinService;


        private PlayerFactory(IObjectResolver objectResolver, PlayerSkinService playerSkinService)
        {
            _objectResolver = objectResolver;
            _playerSkinService = playerSkinService;
        }
        
        public GameObject Create() => _objectResolver.Instantiate(_playerSkinService.GetSkin());
    }
}