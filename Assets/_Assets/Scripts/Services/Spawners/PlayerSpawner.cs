using _Assets.Scripts.Services.Factories;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Spawners
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [Inject] private PlayerFactory _playerFactory;
        
        public GameObject Spawn()
        {
            var skin = _playerFactory.Create();
            skin.transform.position = spawnPoint.position;
            skin.transform.rotation = spawnPoint.rotation;
            return skin;
        }

        public GameObject SpawnGameplay()
        {
            var player = _playerFactory.CreateGameplay();
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
            var skin = _playerFactory.Create();
            skin.transform.parent = player.transform;
            return player;
        }
    }
}