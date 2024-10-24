using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private GameObject _loseEffect;
        [SerializeField] private GameObject _spawnEffect;
        [SerializeField] private Transform _effectsSpawnPoint;
        [SerializeField] private LayerMask _GroundMask;
        private Health _health;
        
        private PlayerConfig _playerConfig;
        
        public void Initialize(PlayerConfig playerConf, Health health)
        {
            _health = health;
            _playerConfig = playerConf;
            SpawnEffect();
            
            _health.Died += OnDied;
        }
        
        public void TakeDamage(int damage)
        {
            if (_playerConfig.CanTakeDamage)
            {
                _health.TakeDamage(damage);
            }
        }

        private void OnDied()
        {
            _playerConfig.ChangeToLoseState();
            Instantiate(_loseEffect, _effectsSpawnPoint.position, Quaternion.identity);
        }

        public void SpawnEffect()
        {
            Ray ray = new Ray(_effectsSpawnPoint.position, Vector3.down);
            if (Physics.Raycast(ray.origin, Vector3.down, out RaycastHit hit, _GroundMask))
            {
                var effect = Instantiate(_spawnEffect, hit.point, Quaternion.identity);
                effect.transform.parent = gameObject.transform;
            }
        }

        public void GoIdle() => _playerConfig.ChangeToIdleState();
    }
}