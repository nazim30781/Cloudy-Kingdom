using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects
{
    public interface IChanged
    {
        public MeshFilter Mesh { get; set; }
        public ChangableObject Levels { get; set; }
        public void ChangeMesh(int level);
    }
}