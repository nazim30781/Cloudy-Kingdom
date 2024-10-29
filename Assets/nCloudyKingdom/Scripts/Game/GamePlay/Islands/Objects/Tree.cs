using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects
{
    public class Tree : IChanged
    {
        public ChangableObject Levels { get; set; }
        public MeshFilter Mesh { get; set; }
        
        public Tree(MeshFilter mesh)
        {
            Mesh = mesh;
            Levels = Resources.Load<ChangableObject>("Objects/Tree");
        }
        
        public void ChangeMesh(int level)
        {
            
            var id = Random.Range(0, Levels.Levels.Types[level].ObjectTypes.Count);
            
            Mesh.mesh = Levels.Levels.Types[level].ObjectTypes[id];
        }
    }
}