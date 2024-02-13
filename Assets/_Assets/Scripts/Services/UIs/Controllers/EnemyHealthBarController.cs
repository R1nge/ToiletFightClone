using _Assets.Scripts.Gameplay.Enemies;
using _Assets.Scripts.Services.UIs.Views;
using UnityEngine;

namespace _Assets.Scripts.Services.UIs.Controllers
{
    public class EnemyHealthBarController : MonoBehaviour
    {
        [SerializeField] private HealthBarView healthBarView;
        private EnemyController _enemyController;

        private void Awake()
        {
            _enemyController = GetComponent<EnemyController>();
            _enemyController.OnHealthChanged += UpdateHealth;
        }

        private void UpdateHealth(int currentHealth, int maxHealth) => healthBarView.UpdateHealthBar(currentHealth, maxHealth);

        private void OnDestroy() => _enemyController.OnHealthChanged -= UpdateHealth;
    }
}