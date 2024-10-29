using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Character.Stats;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public static class PlayerStats
    {
        public static string SPEED = "speed";
        public static string HEALTH = "health";
        public static string ATTACKTIME = "attacktime";
        public static string JUMPFORCE = "jumpforce";
        
        public static Dictionary<string, int> LEVELS = new Dictionary<string, int>()
        {
            {SPEED, 1},
            {HEALTH, 1},
            {ATTACKTIME, 1},
            {JUMPFORCE, 1}
        };

        public static float Speed => SpeedStats.Speed[LEVELS[SPEED]];
        public static int Health => HealthStats.Health[LEVELS[HEALTH]];
        public static float AttackTime => AttackTimeStats.AttackTime[LEVELS[ATTACKTIME]];
        public static float JumpForce => JumpForceStats.JumpForce[LEVELS[JUMPFORCE]];

    }
}