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
            var player = _playerFactory.Create();
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
            return player;
        }
    }
}