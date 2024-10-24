using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyHitBox : MonoBehaviour, IAttackable
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private GameObject _loseEffect;

        private Health _health;
        public void Initialize(EnemyConfig enemyConfig, Health health)
        {
            _enemyConfig = enemyConfig;
            _health = health;
            _health.Died += OnDied;
        }
        public void TakeDamage()
        {
            _health.TakeDamage(10);
            _enemyConfig.OnTakeDamage();
        }

        private void OnDied()
        {
            _enemyConfig.ChangeLoseState();
            SpawnEffect();
        }

        private void SpawnEffect()
        {
            var pos = transform.position;
            pos.y += 5;
            Instantiate(_loseEffect, pos, Quaternion.identity);
        }

    }
}