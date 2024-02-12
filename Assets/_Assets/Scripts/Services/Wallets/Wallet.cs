using System;
using UnityEngine;

namespace _Assets.Scripts.Services.Wallets
{
    public class Wallet
    {
        public WalletData walletData;
        public event Action<int> OnMoneyChanged;

        public void Add(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogError($"Trying to add {amount} money");
                return;
            }

            walletData.money += amount;
            OnMoneyChanged?.Invoke(walletData.money);
        }

        public bool Spend(int amount)
        {
            if (amount < 0)
            {
                Debug.LogError($"Trying to spend {amount} money");
                return false;
            }

            if (amount > walletData.money)
            {
                Debug.LogError($"Not enough money to spend {amount} money");
                return false;
            }
            
            walletData.money -= amount;
            OnMoneyChanged?.Invoke(walletData.money);
            return true;
        }
        
        [Serializable]
        public struct WalletData
        {
            public int money;

            public WalletData(int money)
            {
                this.money = money;
            }
        }
    }
}