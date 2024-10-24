using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class Skeleton : EnemyPatrollerConfig, IPatroller
    {
        [SerializeField] private EnemyPatrollerHandler enemyPatrollerHandler;
        [SerializeField] private EnemyAttackHandler _attackHandler;
        [SerializeField] private EnemyHitBox _hitBox;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private Health _health;

        private NavMeshAgent _agent;
        
        private AttackState _attackState;
        private FollowState _followState;
        private PatrollMoveState _patrollMoveState;
        private PatrollState _patrollState;

        public override void Init(List<Transform> targets)
        {
            base.Init(targets);
            
            _agent = GetComponent<NavMeshAgent>();
            
            _health.Initialize();
            _healthBar.Initialize(_health);

            _patrollState = new PatrollState(this, _animator, enemyPatrollerHandler);
            _patrollMoveState = new PatrollMoveState(this, _animator, enemyPatrollerHandler);
            _followState = new FollowState(this, _animator, _agent, enemyPatrollerHandler);
            _attackState = new AttackState(this, _animator, _attackHandler);
                
            enemyPatrollerHandler.Initialize(_targets, _agent, this);
            _hitBox.Initialize(this, _health);
            _attackHandler.Initialize();
        }

        public void MoveNextTarget() => _stateMachine.ChangeState(_patrollMoveState);
        public void ChangeToPatrolState() => _stateMachine.ChangeState(_patrollState);
        public void StartFollow() => _stateMachine.ChangeState(_followState);
        public void ChangeToAttackState() => _stateMachine.ChangeState(_attackState);
        public override void BaseBehaviour() => _stateMachine.ChangeState(_patrollState);
        public override void AfterAttackAction() => MoveNextTarget();

        public override void OnTakeDamage()
        {
            if (_stateMachine.CurrentState != _attackState)
            {
                _stateMachine.ChangeState(_attackState);
            }
        }

        public override void OnLose() => Destroy(_agent);

        public override void Lose() => Destroy(gameObject);
    }
}