using System;
using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.utils
{
    [Serializable]
    public class LevelsObjects
    {
        public List<Types> Types;
    }

    [Serializable]
    public class Types
    {
        public List<Mesh> ObjectTypes;
    }
}