using System;
using UnityEngine;

namespace _Assets.Scripts.Services.Wallets
{
    public class Wallet
    {
        public int Money { get; set; }
        public event Action<int> OnMoneyChanged;

        public void Add(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogError($"Trying to add {amount} money");
                return;
            }

            Money += amount;
            OnMoneyChanged?.Invoke(Money);
        }

        public bool Spend(int amount)
        {
            if (amount < 0)
            {
                Debug.LogError($"Trying to spend {amount} money");
                return false;
            }

            if (amount > Money)
            {
                Debug.LogError($"Not enough money to spend {amount} money");
                return false;
            }
            
            Money -= amount;
            OnMoneyChanged?.Invoke(Money);
            return true;
        }
    }
}