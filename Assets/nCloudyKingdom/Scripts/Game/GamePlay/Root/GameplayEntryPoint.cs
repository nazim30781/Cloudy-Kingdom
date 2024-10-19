using nCloudyKingdom.Scripts.Game.GamePlay.Camera;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private CameraPriorityController _cameraSystem;
        [SerializeField] private EnemysFabric _enemysFabric;
        public void Run(UIRootView rootView)
        {
            _cameraSystem.Initialize();
            _enemysFabric.Initialize();
        }
    }
}    