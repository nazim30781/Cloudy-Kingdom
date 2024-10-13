using nCloudyKingdom.Scripts.Game.GamePlay.Camera;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root.Installers
{
    public class GameplayUIInstaller : MonoInstaller
    {
        [SerializeField] private CameraPriorityController _cameraController;
        public override void InstallBindings()
        {
            Container.Bind<CameraPriorityController>().FromInstance(_cameraController).AsSingle();
        }
    }
}