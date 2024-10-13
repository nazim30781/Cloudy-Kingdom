using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public interface IAttackable
    {
        public void TakeDamage();

        public Vector3 GetDestinationPoint();
    }
}