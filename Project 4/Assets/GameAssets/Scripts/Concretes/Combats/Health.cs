using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project4.Concretes.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth;
        [SerializeField] int currentHealth;

        public bool IsDead => currentHealth < 1;
        public event System.Action<int, int> OnHealthChanged;
        public event System.Action OnDead;

        private void Awake()
        {
            currentHealth = maxHealth;
        }
        private void Start()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
        public void TakingHit(Damage damage)
        {
            if (IsDead) return;
            currentHealth -= damage.DamageOfHit;

            if (IsDead)
            {
                OnDead?.Invoke();
            }
            else
            {
                OnHealthChanged?.Invoke(currentHealth, maxHealth);
            }
        }
    }
}


