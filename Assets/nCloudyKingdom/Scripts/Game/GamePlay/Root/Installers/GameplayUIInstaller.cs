using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root.Installers
{
    public class GameplayUIInstaller : MonoInstaller
    {
        [SerializeField] private GamePlayUI _gamePlayUI;
        public override void InstallBindings()
        {
            Container.Bind<GamePlayUI>().FromInstance(_gamePlayUI).AsSingle().NonLazy();
        }
    }
}