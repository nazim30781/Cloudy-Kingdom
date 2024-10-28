using System;
using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Portal;
using nCloudyKingdom.Scripts.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Timeline;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _enemySpawnTime;
        public TransformList _targets;
        [SerializeField] private EnemySpawnTrigger _spawnTrigger;

        private float _currentEnemySpawnTime;
        private SkeletonFabric _skeletonFabric;
        private EnemyCounter _enemyCounter;

        public void Start()
        {
            _spawnTrigger.Initialize();
            
            _skeletonFabric = new SkeletonFabric();
            _enemyCounter = new EnemyCounter();
            _spawnTrigger.Trigger += OnTrigger;
        }

        private void OnTrigger()
        {
            if (_currentEnemySpawnTime <= 0 && _enemyCounter.Enemies.Count == 0)
            {
                SpawnEnemies();
                _currentEnemySpawnTime = _enemySpawnTime;
            }
        }

        private void SpawnEnemies()
        {
            foreach (var target in _targets.TransformsList)
            {
                var skeleton = _skeletonFabric.SpawnEnemy(target.Targets);
                _enemyCounter.Enemies.Add(skeleton);
                skeleton.Losed += _enemyCounter.RemoveFromList;
                skeleton.transform.position = target.Targets[1].position;
            }
        }
    }
}