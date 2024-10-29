using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Islands.Objects
{
    public class Stone : IChanged
    {
        public ChangableObject Levels { get; set; }
        public MeshFilter Mesh { get; set; }

        public Stone(MeshFilter mesh)
        {
            Mesh = mesh;
            Levels = Resources.Load<ChangableObject>("Objects/Stone");
        }
        
        public void ChangeMesh(int level)
        {
            var id = Random.Range(0, Levels.Levels.Types[level].ObjectTypes.Count);
            
            Mesh.mesh = Levels.Levels.Types[level].ObjectTypes[id];
        }
    }
}