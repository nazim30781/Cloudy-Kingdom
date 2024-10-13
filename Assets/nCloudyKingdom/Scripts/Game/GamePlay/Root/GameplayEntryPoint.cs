using nCloudyKingdom.Scripts.Game.GamePlay.Camera;
using UnityEngine;
using Player = nCloudyKingdom.Scripts.Game.GamePlay.Character.Player;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private CameraPriorityController _cameraSystem;
        public void Run(UIRootView rootView)
        {
            _cameraSystem.Initialize();
        }
    }
}    