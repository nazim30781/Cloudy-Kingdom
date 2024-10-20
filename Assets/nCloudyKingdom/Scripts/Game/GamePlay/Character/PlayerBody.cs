using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private GameObject _loseEffect;
        [SerializeField] private GameObject _spawnEffect;
        [SerializeField] private Transform _effectsSpawnPoint;
        [SerializeField] private LayerMask _GroundMask;

        private PlayerConf _playerConf;
        private int _currentHealth;
        
        public void Initialize(PlayerConf playerConf)
        {
            _currentHealth = _health;
            _playerConf = playerConf;
            Instantiate(_spawnEffect, _effectsSpawnPoint.position, Quaternion.identity);
        }
        
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _playerConf.Lose();
                Instantiate(_loseEffect, _effectsSpawnPoint.position, Quaternion.identity);
            }
        }

        public void SpawnEffect()
        {
            Ray ray = new Ray(_effectsSpawnPoint.position, Vector3.down);
            if (Physics.Raycast(ray.origin, Vector3.down, out RaycastHit hit, _GroundMask))
            {
                Instantiate(_spawnEffect, hit.point, Quaternion.identity);
            }
        }

        public void Teleport()
        {
            _playerConf.ChangeToTeleportState();
        }

        public void GoIdle() => _playerConf.ChangeToIdleState();
    }
}