using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root.Installers
{
    public class GameplayPlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player playerConf;
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Player>(playerConf);
            playerInstance.Initialize();
            Container.Bind<Player>().FromInstance(playerInstance).AsSingle();
        }
    }
}