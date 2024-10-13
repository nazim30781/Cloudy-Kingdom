using nCloudyKingdom.Scripts.Game.GamePlay.Camera;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GamePlayUI : MonoBehaviour
    {
        [Inject] private CameraPriorityController _cameraPriorityController;

        private void Update()
        {
            if (_cameraPriorityController)
            {
                print("has");
            }
        }

        public void ChangeCamera()
        {
            _cameraPriorityController.ChangeCamera();
        }
    }
}