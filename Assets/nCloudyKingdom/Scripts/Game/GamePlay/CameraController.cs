using System;
using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay
{
    public class CameraController : MonoBehaviour
    {
        [Inject] private PlayerConfig _playerConfig;
        [SerializeField] private CinemachineCamera _camera;

        public void Initialize()
        {
            _camera.Target.TrackingTarget = _playerConfig.transform;
        }
    }
}