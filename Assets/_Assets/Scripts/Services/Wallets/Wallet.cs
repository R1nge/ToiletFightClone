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

            walletData.Money += amount;
            OnMoneyChanged?.Invoke(walletData.Money);
        }

        public bool Spend(int amount)
        {
            if (amount < 0)
            {
                Debug.LogError($"Trying to spend {amount} money");
                return false;
            }

            if (amount > walletData.Money)
            {
                Debug.LogError($"Not enough money to spend {amount} money");
                return false;
            }
            
            walletData.Money -= amount;
            OnMoneyChanged?.Invoke(walletData.Money);
            return true;
        }
        
        [Serializable]
        public struct WalletData
        {
            public int Money;

            public WalletData(int money)
            {
                Money = money;
            }
        }
    }
}