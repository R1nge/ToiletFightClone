using _Assets.Scripts.Services.Datas;

namespace _Assets.Scripts.Services
{
    public class PlayerUpgradeService
    {
        private PlayerData _playerData = new(10, 10, 10, 5, .5f);
        public PlayerData PlayerData => _playerData;

        public bool TryUpgradeDamage(int money, int cost)
        {
            if (money >= cost)
            {
                _playerData.damage += 10;
                return true;
            }

            return false;
        }

        public bool TryUpgradeHealth(int money, int cost)
        {
            if (money >= cost)
            {
                _playerData.health += 10;
                return true;
            }

            return false;
        }
    }
}