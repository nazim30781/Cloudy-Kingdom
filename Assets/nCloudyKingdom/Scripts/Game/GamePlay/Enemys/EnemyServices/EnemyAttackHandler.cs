using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyAttackHandler : MonoBehaviour, IAttacker
    {
        [SerializeField] protected float _attackTime;
        public float AttackTime { get; private set; }

        public virtual void Initialize()
        {
            AttackTime = _attackTime;
        }
        
        public virtual void Attack(PlayerBody body)
        {
            body.TakeDamage(10);
        }
    }
}