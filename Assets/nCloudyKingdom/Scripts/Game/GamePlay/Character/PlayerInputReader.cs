using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.EventSystems;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerInputReader : MonoBehaviour
    {
        private UnityEngine.Camera mainCamera;
        private PlayerMovementHandler _movementHandler;
        private PlayerFollowHandler _followHandler;
        private PlayerConf _playerConf;

        public void Initialize(PlayerConf playerConf, PlayerMovementHandler movementHandler, PlayerFollowHandler followHandler)
        {
            mainCamera = UnityEngine.Camera.main;
            _movementHandler = movementHandler;
            _followHandler = followHandler;
            _playerConf = playerConf;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit ))
                {
                    if (hit.collider.TryGetComponent(out IAttackable enemy))
                    {
                        _followHandler.CurrentTarget = hit.transform;
                        _playerConf.ChangeToFollowState();
                    }
                    else
                    {
                        _followHandler.CurrentTarget = null;
                        _movementHandler.Move(hit.point);
                    }
                }
            }
        }
    }
}