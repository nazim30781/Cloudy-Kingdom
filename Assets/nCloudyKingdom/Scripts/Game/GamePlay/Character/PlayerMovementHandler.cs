using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private PlayerConf playerConf;
        
        private NavMeshAgent _agent;
        
        public void Initialize(NavMeshAgent agent)
        {
            _agent = agent;
        }

        private void Update()
        {
            MovementHandler();
        }

        public void Move(Vector3 point)
        {
            _agent.SetDestination(point);
            _agent.isStopped = false;
            if (!playerConf.IsMovementState())
            {
                playerConf.ChangeToMoveState();
            }
        }

        private void MovementHandler()
        {
            if (_agent.velocity == Vector3.zero && !playerConf.IsAttackState() && !playerConf.IsIdleState() && !playerConf.IsFollowState())
                playerConf.ChangeToIdleState();

            if (_agent.velocity != Vector3.zero && !playerConf.IsAttackState() && !playerConf.IsMovementState() && !playerConf.IsFollowState()) 
                playerConf.ChangeToMoveState();

            if (playerConf.IsMovementState())
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