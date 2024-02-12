using System;

namespace _Assets.Scripts.Services.Datas
{
    [Serializable]
    public struct PlayerData
    {
        public int damage;
        public int health;

        public PlayerData(int damage, int health)
        {
            this.damage = damage;
            this.health = health;
        }
    }
}