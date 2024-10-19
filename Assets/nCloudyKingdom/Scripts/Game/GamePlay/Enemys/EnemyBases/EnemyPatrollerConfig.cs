using System;
using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyPatrollerConfig : EnemyConfig
    {
        protected List<Transform> _targets;
        
        public virtual void Init(List<Transform> targets)
        {
            base.Initialize();
            _targets = targets;
        }
    }
}