using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [Inject] private PlayerConfig _playerConfig;
        
        [FormerlySerializedAs("_enemysFabric")] [SerializeField] private EnemiesFabric enemiesFabric;
        [SerializeField] private CameraController _cameraController;
        public void Run(UIRootView rootView)
        {
            enemiesFabric.Initialize();
            _cameraController.Initialize();
            _playerConfig.gameObject.GetComponent<PlayerBody>().SpawnEffect();
        }
    }
}    