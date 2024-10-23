using nCloudyKingdom.Scripts.Game.GamePlay.Root;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerControllerMediator : MonoBehaviour
    {
        private GamePlayUI _gamePlayUI;
        private PlayerController _playerController;
        
        public void Initilize(GamePlayUI gamePlayUI, PlayerController controller)
        {
            _gamePlayUI = gamePlayUI;
            _playerController = controller;
            
            _gamePlayUI.AttackBtn.onClick.AddListener(_playerController.Attack);
            _gamePlayUI.JumpBtn.onClick.AddListener(_playerController.Jump);
        }
    }
}