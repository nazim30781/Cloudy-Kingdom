using nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovementHandler _playerMovementHandler;
        
        private Animator _animator;

        private StateMachine.StateMachine _stateMachine;
        private IdleState _idleState;
        private AttackState _attackState;
        private MovementState _movementState;

        public Transform RayPoint;

        public void Initialize()
        {
            _animator = GetComponent<Animator>();

            _stateMachine = new StateMachine.StateMachine();

            _idleState = new IdleState(this, _animator);
            _attackState = new AttackState(this, _animator);
            _movementState = new MovementState(this, _animator);

            _stateMachine.Initialize(_idleState);
            _playerMovementHandler.Initialize();
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
        }

        public void ChangeToAttackState() => _stateMachine.ChangeState(_attackState);
        public void ChangeToIdleState() => _stateMachine.ChangeState(_idleState);
        public void ChangeToMoveState() => _stateMachine.ChangeState(_movementState);

        public bool IsAttackState() => _stateMachine.CurrentState == _attackState;
        public bool IsIdleState() => _stateMachine.CurrentState == _idleState;
        public bool IsMovementState() => _stateMachine.CurrentState == _movementState;
    }
}