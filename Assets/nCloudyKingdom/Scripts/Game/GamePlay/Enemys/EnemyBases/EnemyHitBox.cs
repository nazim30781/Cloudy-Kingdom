using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyHitBox : MonoBehaviour, IAttackable
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private EnemyConfig _enemyConfig;
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
                _enemyConfig.ChangeLoseState();
            else
                _enemyConfig.OnTakeDamage();
        }
    }
}