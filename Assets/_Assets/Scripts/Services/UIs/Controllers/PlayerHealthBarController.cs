using System;
using _Assets.Scripts.Gameplay.Players;
using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class PlayerHealthBarController : MonoBehaviour
    {
        [SerializeField] private HealthBarView healthBarView;
        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _playerController.OnHealthChanged += UpdateHealthBar;
        }

        private void UpdateHealthBar(int health, int maxHealth) => healthBarView.UpdateHealthBar(health, maxHealth);

        private void OnDestroy() => _playerController.OnHealthChanged -= UpdateHealthBar;
    }
}