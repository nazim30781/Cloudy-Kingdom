using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public class IdleState : EnemyBaseBehaviour
    {
        public IdleState(Enemy enemy, Animator animator) : base(enemy, animator) {}

        public override void OnEnter()
        {
            _animator.SetBool("Idle", true);
        }

        public override void OnExit()
        {
            _animator.SetBool("Idle", false);
        }
    }
}