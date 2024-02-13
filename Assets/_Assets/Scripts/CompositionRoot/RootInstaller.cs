using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Levels;
using _Assets.Scripts.Services.Skins;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class RootInstaller : LifetimeScope
    {
        [SerializeField] private ConfigProvider configProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(configProvider);
            
            builder.Register<GameLevelsService>(Lifetime.Singleton);
            builder.Register<GameSceneService>(Lifetime.Singleton);
            
            builder.Register<Wallet>(Lifetime.Singleton);
            builder.Register<PlayerUpgradeService>(Lifetime.Singleton);

            builder.Register<PlayerSkinService>(Lifetime.Singleton);
            
            builder.Register<PlayerInput>(Lifetime.Singleton);

            if (SceneManager.GetActiveScene().name != "Boot")
            {
                SceneManager.LoadSceneAsync("Boot");
            }
        }
    }
}