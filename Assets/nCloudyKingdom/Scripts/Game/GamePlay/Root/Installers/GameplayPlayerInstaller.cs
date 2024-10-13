using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root.Installers
{
    public class GameplayPlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Player>(_player);
            playerInstance.Initialize();
            Container.Bind<Player>().FromInstance(playerInstance).AsSingle();
        }
    }
}