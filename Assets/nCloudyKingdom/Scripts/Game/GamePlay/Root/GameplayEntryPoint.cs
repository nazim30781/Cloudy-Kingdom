using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [Inject] private Player _player;
        
        [SerializeField] private CameraController _cameraController;
        public void Run(UIRootView rootView)
        {
            _cameraController.Initialize();
            _player.gameObject.GetComponent<PlayerBody>().SpawnEffect();
        }
    }
}    