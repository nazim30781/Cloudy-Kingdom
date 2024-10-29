using System.Collections.Generic;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.Stats
{
    public static class AttackTimeStats
    {
        public static Dictionary<int, float> AttackTime = new Dictionary<int, float>()
        {
            {1, 1.5f},
            {2, 1.35f},
            {3, 1.15f},
            {4, 0.95f},
            {5, 0.75f},
        };
    }
}