using nCloudyKingdom.Scripts.Game.GamePlay.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public class PatrollMoveState : EnemyBaseBehaviour
    {
        private EnemyPatrollerHandler _enemyPatrollerHandler;

        public PatrollMoveState(Enemy enemy, Animator animator, EnemyPatrollerHandler enemyPatrollerHandler) : base(enemy,
            animator)
        {
            _enemyPatrollerHandler = enemyPatrollerHandler;
        }

        public override void OnEnter()
        {
            _animator.SetBool("Walk", true);
        }

        public override void Update()
        {
            if (!_enemyPatrollerHandler.HasPath())
            {
                _enemyPatrollerHandler.StartPatrol();
            }
        }

        public override void OnExit()
        {
            _animator.SetBool("Walk", false);
        }
    }
}