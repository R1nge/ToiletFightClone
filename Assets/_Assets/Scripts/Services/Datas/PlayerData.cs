using System;

namespace _Assets.Scripts.Services.Datas
{
    [Serializable]
    public struct PlayerData
    {
        public int damage;
        public int health;
        public float detectRange;
        public float attackRange;
        public float attackCooldown;

        public PlayerData(int damage, int health, float detectRange, float attackRange, float attackCooldown)
        {
            this.damage = damage;
            this.health = health;
            this.detectRange = detectRange;
            this.attackRange = attackRange;
            this.attackCooldown = attackCooldown;
        }
    }
}