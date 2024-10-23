using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root.Installers
{
    public class GameplayPlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig playerConf;
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerConfig>(playerConf);
            playerInstance.Initialize();
            Container.Bind<PlayerConfig>().FromInstance(playerInstance).AsSingle();
        }
    }
}