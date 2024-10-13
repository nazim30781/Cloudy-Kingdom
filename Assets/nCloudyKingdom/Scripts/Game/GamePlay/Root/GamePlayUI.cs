using nCloudyKingdom.Scripts.Game.GamePlay.Camera;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GamePlayUI : MonoBehaviour
    {
        public CameraPriorityController _cameraPriorityController { get; private set; }

        public void ChangeCamera()
        {
            _cameraPriorityController.ChangeCamera();
        }
    }
}