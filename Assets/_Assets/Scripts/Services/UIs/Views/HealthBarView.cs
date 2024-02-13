using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.Views
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;

        public void UpdateHealthBar(int health, int maxHealth)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
    }
}