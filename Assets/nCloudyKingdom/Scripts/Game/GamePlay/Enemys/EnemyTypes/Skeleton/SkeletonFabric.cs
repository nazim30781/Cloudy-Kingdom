using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class SkeletonFabric : EnemiesFabric
    {
        public override Enemy SpawnEnemy(List<Transform> targets)
        {
            Skeleton enemy = Resources.Load<Skeleton>("Prefabs/Enemies/Skeleton");
            var skeleton = GameObject.Instantiate(enemy);
            skeleton.Init(targets);
            return skeleton;
        }
    }
}