using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemiesFabric : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private EnemyPatrollerConfig _enemyPatrollerPrefab;
        [SerializeField] private List<Transform> _targets;

        public void Initialize()
        {
            var instance = Instantiate(_enemyPatrollerPrefab, _spawnPoint.position, Quaternion.identity);
            instance.Init(_targets);
        }
    }
}