using UnityEngine;
using UnityEngine.Serialization;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyHitBox : MonoBehaviour, IAttackable
    {
        [FormerlySerializedAs("_enemyConfig")] [SerializeField] private EnemyBase enemyBase;
        [SerializeField] private GameObject _loseEffect;

        private Health _health;
        public void Initialize(EnemyBase enemyBase, Health health)
        {
            this.enemyBase = enemyBase;
            _health = health;
            _health.Died += OnDied;
        }
        public void TakeDamage(int value)
        {
            _health.TakeDamage(value);
            enemyBase.OnTakeDamage();
        }

        private void OnDied()
        {
            enemyBase.ChangeLoseState();
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