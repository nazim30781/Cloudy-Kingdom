using UnityEngine;
using Player = nCloudyKingdom.Scripts.Game.GamePlay.Character.Player;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _gameplayUI;
        [SerializeField] private Player _player;

        public void Run(UIRootView rootView)
        {
            Player instance = Instantiate(_player);
            instance.Initialize();
            rootView.AttachUI(_gameplayUI);
        }
    }
}    