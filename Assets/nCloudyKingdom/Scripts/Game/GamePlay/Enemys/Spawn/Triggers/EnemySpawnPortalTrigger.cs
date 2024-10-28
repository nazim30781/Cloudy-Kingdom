using System;
using nCloudyKingdom.Scripts.Game.GamePlay.Portal;
using UnityEngine;
using System.Collections;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemySpawnPortalTrigger : EnemySpawnTrigger
    {
        [SerializeField] private Teleport _teleport;

        public override event Action Trigger;

        public override void Initialize() => _teleport.Teleported += OnTeleported;

        private void OnTeleported() => Trigger?.Invoke();
    }
}