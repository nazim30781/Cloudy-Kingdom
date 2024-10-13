using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerAttackHandler _playerAttackHandler;
        
        private UnityEngine.Camera mainCamera;
        private NavMeshAgent _agent;

        public void Initialize()
        {
            mainCamera = UnityEngine.Camera.main;
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit ))
                {
                    _player.ChangeToMoveState();
                    if (hit.collider.TryGetComponent(out IAttackable enemy))
                    {
                        _agent.SetDestination(enemy.GetDestinationPoint());
                        _playerAttackHandler.FollowTarget = true;
                    }
                    else
                    {
                        _agent.SetDestination(hit.point);
                        _agent.isStopped = false;
                    }
                }
            }
            
            MovementHandler();
        }

        private void MovementHandler()
        {
            if (_agent.velocity == Vector3.zero && !_player.IsAttackState())
                _player.ChangeToIdleState();

            if (_agent.velocity != Vector3.zero && !_player.IsAttackState())
                _player.ChangeToMoveState();

            if (_player.IsMovementState())
            {
                var angle = Mathf.Atan2(_agent.velocity.x, _agent.velocity.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }

        public void StopMovement()
        {
            _agent.isStopped = true;
        }

    }
}