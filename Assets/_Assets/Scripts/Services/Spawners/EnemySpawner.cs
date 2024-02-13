using System;
using _Assets.Scripts.Gameplay.Players;
using _Assets.Scripts.Services.Factories;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private WaveData[] waves;
        private int _waveIndex = -1;
        [Inject] private EnemyFactory _enemyFactory;

        public void SpawnNextWave(PlayerController player)
        {
            Debug.Log("Spawn next wave");
            _waveIndex++;

            if (_waveIndex >= waves.Length)
            {
                Debug.LogError("Enemy Spawner: index out of range", this);
                return;
            }

            for (int i = 0; i < waves[_waveIndex].amount; i++)
            {
                var enemy = _enemyFactory.Create(player, waves[_waveIndex].enemyType);
                enemy.transform.position = waves[_waveIndex].spawnPoint.position;
            }
        }

        [Serializable]
        public struct WaveData
        {
            public int amount;
            public EnemyFactory.EnemyType enemyType;
            public Transform spawnPoint;
        }
    }
}