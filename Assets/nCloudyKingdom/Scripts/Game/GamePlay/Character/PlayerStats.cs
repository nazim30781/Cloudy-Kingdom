using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    [CreateAssetMenu(menuName = "Character", fileName = "Stats")]
    public class PlayerStats : ScriptableObject
    {
        public int Health { get; set; }
        public float AttackSpeed { get; set; }
        public float Speed { get; set; }
    }
}