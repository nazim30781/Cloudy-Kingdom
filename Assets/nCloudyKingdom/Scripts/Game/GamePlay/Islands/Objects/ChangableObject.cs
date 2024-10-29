using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Islands.utils;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects
{
    [CreateAssetMenu(menuName = "Islands/Object")]
    public class ChangableObject : ScriptableObject
    {
        public LevelsObjects Levels;
    }
}