using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects
{
    public class House : IChanged
    {
        public ChangableObject Levels { get; set; }
        public MeshFilter Mesh { get; set; }

        public House(MeshFilter mesh)
        {
            Mesh = mesh;
            Levels = Resources.Load<ChangableObject>("Objects/House");
        }
        
        public void ChangeMesh(int level)
        {
            var id = Random.Range(0, Levels.Levels.Types[level].ObjectTypes.Count);
            
            Mesh.mesh = Levels.Levels.Types[level].ObjectTypes[id];
        }
    }
}