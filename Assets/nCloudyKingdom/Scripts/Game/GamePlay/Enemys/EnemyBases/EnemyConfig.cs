using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyConfig : Enemy
    {
        protected IdleState _idleState;
        protected LoseState _loseState;

        public override void Initialize()
        {
            _stateMachine = new StateMachine.StateMachine();
            _animator = GetComponent<Animator>();

            _idleState = new IdleState(this, _animator);
            _loseState = new LoseState(this, _animator);
                
            _stateMachine.Initialize(_idleState);
        }
        public void ChangeLoseState() => _stateMachine.ChangeState(_loseState);
        public override void BaseBehaviour() => _stateMachine.ChangeState(_idleState);
        public virtual void OnTakeDamage() {}
        public override void Lose() => Destroy(gameObject);
    }
}