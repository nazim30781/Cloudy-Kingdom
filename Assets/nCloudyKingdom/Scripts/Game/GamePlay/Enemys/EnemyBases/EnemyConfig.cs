using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    [CreateAssetMenu(menuName = "Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float AttackTime { get; private set; }
        [field: SerializeField] public float PatrolDistance { get; private set; }
        [field: SerializeField] public float AttackDistance { get; private set; }
        [field: SerializeField] public int DamageCount { get; private set; }
    }
}