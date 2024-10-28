using System;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public abstract class EnemySpawnTrigger : MonoBehaviour
    {
        public virtual void Initialize() {}
        public abstract event Action Trigger;
    }
}