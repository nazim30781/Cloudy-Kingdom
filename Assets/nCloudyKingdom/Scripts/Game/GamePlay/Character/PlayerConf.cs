using nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerConf : MonoBehaviour
    {
        [SerializeField] private PlayerMovementHandler _playerMovementHandler;
        [SerializeField] private PlayerFollowHandler _playerFollowHandler;
        [SerializeField] private PlayerBody _playerBody;
        [SerializeField] private PlayerInputReader _playerInputReader;

        private Animator _animator;
        private NavMeshAgent _agent;

        private StateMachine.StateMachine _stateMachine;
        private IdleState _idleState;
        private AttackState _attackState;
        private MovementState _movementState;
        private FollowState _followState;
        private LoseState _loseState;
        
        public Transform RayPoint;

        public void Initialize()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _stateMachine = new StateMachine.StateMachine();

            _idleState = new IdleState(this, _animator);
            _attackState = new AttackState(this, _animator);
            _movementState = new MovementState(this, _animator);
            _loseState = new LoseState(this, _animator);

            _stateMachine.Initialize(_idleState);
            _playerMovementHandler.Initialize(_agent);
            _playerFollowHandler.Initialize(this, _agent);
            _playerBody.Initialize(this);
            _playerInputReader.Initialize(this, _playerMovementHandler, _playerFollowHandler);

            _followState = new FollowState(this, _animator, _playerFollowHandler);
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
            if (Input.GetKeyDown(KeyCode.A))
                _playerBody.TakeDamage(10);
        }

        public void OnLose()
        {
            _agent.isStopped = true;
            _playerInputReader.enabled = false;
            _playerBody.enabled = false;
            _playerMovementHandler.enabled = false;
            _playerFollowHandler.enabled = false;
        }

        public void ChangeToAttackState() => _stateMachine.ChangeState(_attackState);
        public void ChangeToIdleState() => _stateMachine.ChangeState(_idleState);
        public void ChangeToMoveState() => _stateMachine.ChangeState(_movementState);
        public void ChangeToFollowState() => _stateMachine.ChangeState(_followState);
        public void Lose() => _stateMachine.ChangeState(_loseState);
        public bool IsAttackState() => _stateMachine.CurrentState == _attackState;
        public bool IsMovementState() => _stateMachine.CurrentState == _movementState;
        public bool IsFollowState() => _stateMachine.CurrentState == _followState;
        public bool IsIdleState() => _stateMachine.CurrentState == _idleState;

        public void Dead()
        {
            Destroy(gameObject);
        }
    }
}