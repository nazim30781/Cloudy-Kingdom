using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerBody : MonoBehaviour
    {
        [SerializeField] private int _health;

        private PlayerConf _playerConf;
        private int _currentHealth;
        
        public void Initialize(PlayerConf playerConf)
        {
            _currentHealth = _health;
            _playerConf = playerConf;
        }
        
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _playerConf.Lose();
            }
        }
    }
}