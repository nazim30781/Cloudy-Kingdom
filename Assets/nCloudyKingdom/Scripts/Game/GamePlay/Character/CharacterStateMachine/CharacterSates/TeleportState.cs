using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class TeleportState : BaseCharacterBehaviour
    {
        private NavMeshAgent _agent;

        public TeleportState(PlayerConf playerConf, Animator animator, NavMeshAgent agent) : base(playerConf, animator)
        {
            _agent = agent;
        }
        
        public override void OnEnter()
        {
            _agent.enabled = false;
            _animator.SetTrigger("Teleport");
        }

        public override void OnExit()
        {
            _agent.enabled = true;
        }
    }
}