using nCloudyKingdom.Scripts.Game.GamePlay.Portal;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Teleport _teleport;
        [SerializeField] private float _enemySpawnTime;

        private float _currentEnemySpawnTime;
        
        public void Initialize()
        {
            _teleport.Teleported += OnPlayerTeleport;
        }

        private void OnPlayerTeleport()
        {
            if (_currentEnemySpawnTime <= 0)
            {
                SpawnEnemies();
                _currentEnemySpawnTime = _enemySpawnTime;
            }
        }

        private void SpawnEnemies()
        {
            
        }
    }
}