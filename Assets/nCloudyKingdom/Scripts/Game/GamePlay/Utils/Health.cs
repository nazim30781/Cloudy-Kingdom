﻿using System;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

        private int _currentHealth;

        public event Action<float> HealthChanged;
        public event Action Died;

        public void Initialize(int health=0)
        {
            if (health > 0)
                _maxHealth = health;
            
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int value)
        {
            if (value > 0)
            {
                _currentHealth -= value;

                if (_currentHealth < 0)
                    _currentHealth = 0;

                HealthChanged?.Invoke((float) _currentHealth / _maxHealth);

                if (_currentHealth == 0)
                    Died?.Invoke();
            }
        }
    }
}