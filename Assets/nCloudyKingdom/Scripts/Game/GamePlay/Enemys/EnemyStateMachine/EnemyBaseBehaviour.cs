using nCloudyKingdom.Scripts.Game.GamePlay.StateMachine;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public abstract class EnemyBaseBehaviour : IState
    {
        protected readonly Enemy _enemy;
        protected readonly Animator _animator;

        protected EnemyBaseBehaviour(Enemy enemy, Animator animator)
        {
            _enemy = enemy;
            _animator = animator;
        }
        
        public virtual void OnEnter()
        {
            
        }

        public virtual void Update()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}