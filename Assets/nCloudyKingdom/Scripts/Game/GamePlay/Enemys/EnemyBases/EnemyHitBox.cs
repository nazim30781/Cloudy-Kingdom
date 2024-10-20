using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyHitBox : MonoBehaviour, IAttackable
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private GameObject _loseEffect;
        private int _currentHealth;

        public void Initialize(EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
            _currentHealth = _maxHealth;
        }
        public void TakeDamage()
        {
            _currentHealth -= 10;

            if (_currentHealth <= 0)
            {
                _enemyConfig.ChangeLoseState();
                var pos = transform.position;
                pos.y += 5;
                Instantiate(_loseEffect, pos, Quaternion.identity);
            }
            else
                _enemyConfig.OnTakeDamage();
        }
    }
}