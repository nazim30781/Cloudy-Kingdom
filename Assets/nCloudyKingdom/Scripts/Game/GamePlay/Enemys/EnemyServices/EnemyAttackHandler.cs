using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyAttackHandler : MonoBehaviour, IAttacker
    {
        public int DamageCount { get; private set; }

        public virtual void Initialize(EnemyConfig config)
        {
            DamageCount = config.DamageCount;
        }
        
        public virtual void Attack(PlayerBody body)
        {
            body.TakeDamage(DamageCount);
        }
    }
}