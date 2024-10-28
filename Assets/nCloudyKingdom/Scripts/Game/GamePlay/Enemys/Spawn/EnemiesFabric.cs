using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public abstract class EnemiesFabric
    {
        public abstract Enemy SpawnEnemy(List<Transform> targets);
    }
}