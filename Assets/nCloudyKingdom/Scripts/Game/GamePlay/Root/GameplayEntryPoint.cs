using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemysFabric _enemysFabric;
        [SerializeField] private CameraController _cameraController;
        public void Run(UIRootView rootView)
        {
            _enemysFabric.Initialize();
            _cameraController.Initialize();
        }
    }
}    