using nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates;
using nCloudyKingdom.Scripts.Game.GamePlay.Root;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerConfig : MonoBehaviour
    {
        [Inject] private GamePlayUI _gamePlayUI;
        
        [SerializeField] private PlayerBody _playerBody;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerControllerMediator _controllerMediator;
        [SerializeField] private Health _health;
        [SerializeField] private HealthBar _healthBar;

        private Animator _animator;
        private CharacterController _controller;
        
        private StateMachine.StateMachine _stateMachine;
        private IdleState _idleState;
        private AttackState _attackState;
        private MovementState _movementState;
        private LoseState _loseState;
        private JumpState _jumpState;
        
        public Transform AttackPoint;
        
        public bool CanChangeState;
        public bool CanTakeDamage;

        public void Initialize()
        {
            CanChangeState = true;
            CanTakeDamage = true;
            
            _animator = GetComponent<Animator>();
            _controller = GetComponent<CharacterController>();
            
            _stateMachine = new StateMachine.StateMachine();
            
            _health.Initialize();
            _healthBar.Initialize(_health);
            _playerController.Initialize(this, _gamePlayUI);
            _playerBody.Initialize(this, _health);
            _controllerMediator.Initilize(_gamePlayUI, _playerController);

            _idleState = new IdleState(this, _animator);
            _attackState = new AttackState(this, _animator);
            _movementState = new MovementState(this, _animator);
            _loseState = new LoseState(this, _animator);
            _jumpState = new JumpState(this, _animator, _playerController);

            _stateMachine.Initialize(_idleState);
        }

        public void ChangeToMovementState() => _stateMachine.ChangeState(_movementState);
        public void ChangeToIdleState() => _stateMachine.ChangeState(_idleState);
        public void ChangeToAttackState() => _stateMachine.ChangeState(_attackState);
        public void ChangeToJumpState() => _stateMachine.ChangeState(_jumpState);
        public void ChangeToLoseState() => _stateMachine.ChangeState(_loseState);

        public bool IsMovementState() => _stateMachine.CurrentState == _movementState;
        public bool IsIdleState() => _stateMachine.CurrentState == _idleState;
        
        private void Update()
        {
            _stateMachine.CurrentState.Update();
        }

        public void OnLose()
        {
            Destroy(_playerBody);
            Destroy(_playerController);
            Destroy(_controller);
        }
        
        public void Dead() => Destroy(gameObject);
    }
}