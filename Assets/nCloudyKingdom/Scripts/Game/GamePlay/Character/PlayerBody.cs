using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private GameObject _loseEffect;
        [SerializeField] private GameObject _spawnEffect;
        [SerializeField] private Transform _effectsSpawnPoint;
        
        private Health _health;
        private CharacterController _controller;
        private Player _player;
        
        public void Initialize(Player playerConf, Health health, CharacterController controller)
        {
            _controller = controller;
            _health = health;
            _player = playerConf;
            
            SpawnEffect();
            
            _health.Died += OnDied;
        }
        
        public void TakeDamage(int damage)
        {
            if (_player.CanTakeDamage)
                _health.TakeDamage(damage);
        }

        private void OnDied()
        {
            _player.ChangeToLoseState();
            SpawnEffect(_loseEffect);
        }

        public void SpawnEffect(GameObject effectType=null)
        {
            if (effectType==null)
                Instantiate(_spawnEffect, _effectsSpawnPoint);
            else
                Instantiate(effectType, _effectsSpawnPoint);
        }

        public void Teleport() => _controller.enabled = false;

        public void GoIdle()
        {
            _controller.enabled = true;
            _player.ChangeToIdleState();
        }
    }
}