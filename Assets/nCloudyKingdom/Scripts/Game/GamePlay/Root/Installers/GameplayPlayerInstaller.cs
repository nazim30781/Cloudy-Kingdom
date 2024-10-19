using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root.Installers
{
    public class GameplayPlayerInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_player")] [SerializeField] private PlayerConf playerConf;
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerConf>(playerConf);
            playerInstance.Initialize();
            Container.Bind<PlayerConf>().FromInstance(playerInstance).AsSingle();
        }
    }
}