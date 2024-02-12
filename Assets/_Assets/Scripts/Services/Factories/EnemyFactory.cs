using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Enemies;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Factories
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private EnemyFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public GameObject Create(Transform player, EnemyType enemyType)
        {
            var enemy = _objectResolver.Instantiate(_configProvider.EnemiesConfig.GetDataByEnemyType(enemyType).enemyPrefab);
            var enemyController = enemy.GetComponent<EnemyController>();
            enemyController.SetPlayerReference(player);
            return enemy;
        }
        
        public enum EnemyType : byte
        {
            ToiletArt = 0,
            ToiletErdim = 1,
            ToiletEric = 2,
            ToiletJoe = 3,
            ToiletMike = 4,
            ToiletSandro = 5,
            ToiletTed = 6
        }
    }
}