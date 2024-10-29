using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects
{
    public class Water : IChanged
    {
        public MeshFilter Mesh { get; set; }
        public ChangableObject Levels { get; set; }

        public Water(MeshFilter mesh)
        {
            Mesh = mesh;
            Levels = Resources.Load<ChangableObject>("Objects/Waters");
        }
        
        public void ChangeMesh(int level)
        {
            var id = Random.Range(0, Levels.Levels.Types[level].ObjectTypes.Count);
            
            Mesh.mesh = Levels.Levels.Types[level].ObjectTypes[id];
        }
    }
}