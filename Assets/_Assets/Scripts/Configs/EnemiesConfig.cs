using System;
using _Assets.Scripts.Services.Factories;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Enemies Config", menuName = "Configs/Enemies Config")]
    public class EnemiesConfig : ScriptableObject
    {
        [SerializeField] private EnemyData[] _enemyDatas;

        public EnemyData GetDataByEnemyType(EnemyFactory.EnemyType enemyType)
        {
            for (int i = 0; i < _enemyDatas.Length; i++)
            {
                if (_enemyDatas[i].enemyType == enemyType)
                {
                    return _enemyDatas[i];
                }
            }

            Debug.LogError("Enemy not found in the config");
            return null;
        }

        [Serializable]
        public class EnemyData
        {
            public EnemyFactory.EnemyType enemyType;
            public GameObject enemyPrefab;
        }
    }
}