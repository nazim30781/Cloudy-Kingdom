using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerFollowHandler : MonoBehaviour
    {
        private PlayerConf _playerConf;
        private NavMeshAgent _agent;
        
        public Transform CurrentTarget;

        public void Initialize(PlayerConf playerConf, NavMeshAgent agent)
        {
            _agent = agent;
            _playerConf = playerConf;
        }

        public void Follow()
        {
            if (CurrentTarget == null)
            {
                _playerConf.ChangeToIdleState();
                return;
            }
            
            var dir = CurrentTarget.position - _playerConf.transform.position;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            _playerConf.transform.rotation = Quaternion.Euler(0, angle, 0);

            _agent.SetDestination(CurrentTarget.position);

            if (dir.magnitude <= 2.9f)
            {
                _playerConf.ChangeToAttackState();
            }
        }
    }
}