using System;
using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Camera
{
    public class CameraPriorityController: MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _battleCamera;
        [SerializeField] private CinemachineCamera _baseCamera;

        [Inject] private PlayerConf _playerConf;

        public void Initialize()
        {
            var target = _playerConf.transform;
            
            _battleCamera.Target.TrackingTarget = target;
            _baseCamera.Target.TrackingTarget = target;
        }

        public void ChangeCamera()
        {
            if (_battleCamera.Priority.Value == 1)
                SetBaseCamera();
            else
                SetBattleCamera();
        }

        private void SetBattleCamera()
        {
            _battleCamera.Priority.Value = 1;
            _baseCamera.Priority.Value = 0;
        }

        private void SetBaseCamera()
        {
            _baseCamera.Priority.Value = 1;
            _battleCamera.Priority.Value = 0;
        }
    }
}