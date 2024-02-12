using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Levels;
using _Assets.Scripts.Services.Skins;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using _Assets.Scripts.Services.Wallets;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private PlayerSpawner playerSpawner;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameLevelsService>(Lifetime.Singleton);
            
            builder.Register<Wallet>(Lifetime.Singleton);
            builder.Register<PlayerUpgradeService>(Lifetime.Singleton);

            builder.Register<PlayerSkinService>(Lifetime.Singleton);
            builder.Register<PlayerFactory>(Lifetime.Singleton);

            builder.RegisterComponent(playerSpawner);
            
            builder.Register<UIStatesFactory>(Lifetime.Singleton);
            builder.Register<UIStateMachine>(Lifetime.Singleton);
            builder.Register<UIFactory>(Lifetime.Singleton);
            
            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}