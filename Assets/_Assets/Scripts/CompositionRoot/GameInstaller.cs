using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Factories;
using _Assets.Scripts.Services.Spawners;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private EndOfTheLevel endOfTheLevel;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            builder.Register<EnemyFactory>(Lifetime.Singleton);

            builder.Register<UIStatesFactory>(Lifetime.Singleton);
            builder.Register<UIStateMachine>(Lifetime.Singleton);
            builder.Register<UIFactory>(Lifetime.Singleton);
            
            builder.RegisterComponent(playerSpawner);
            builder.RegisterComponent(enemySpawner);

            builder.RegisterComponent(endOfTheLevel);

            builder.Register<GameStatesFactory>(Lifetime.Singleton).As<IStateFactory>();
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}