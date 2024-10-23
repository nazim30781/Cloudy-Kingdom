using System;
using UnityEngine;
using UnityEngine.UI;

namespace nCloudyKingdom.Scripts.Game.GamePlay
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarFilling;
        [SerializeField] private Gradient _gradient;
        
        private Health _health;

        public void Initialize(Health health)
        {
            _health = health;
            _health.HealthChanged += OnHealthChanged;
            _healthBarFilling.color = _gradient.Evaluate(1);
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float value)
        {
            _healthBarFilling.fillAmount = value;
            _healthBarFilling.color = _gradient.Evaluate(value);
        }
    }
}