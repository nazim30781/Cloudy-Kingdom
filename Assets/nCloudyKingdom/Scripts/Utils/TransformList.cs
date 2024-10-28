using System;
using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Utils
{
    [Serializable]
    public class TransformList
    {
        public List<Transforms> TransformsList;
    }
    
    [Serializable]
    public class Transforms
    {
        public List<Transform> Targets;
    }
}