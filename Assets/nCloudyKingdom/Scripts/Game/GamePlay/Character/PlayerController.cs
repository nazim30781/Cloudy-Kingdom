using System;
using nCloudyKingdom.Scripts.Game.GamePlay.Root;
using UnityEngine;
using Zenject;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        
        private float _gravity;
        private float _horizontalAngle;
        private float _attackTime = 1;
        private float _currentAttackTime;
        private Joystick _joystick;
        private Vector3 _moveDirection;
        private Vector3 _velocity;
        private CharacterController _controller;
        private PlayerConfig _playerConfig;
        
        public bool CanMove;

        public void Initialize(PlayerConfig playerConfig, GamePlayUI gamePlayUI)
        {
            _controller = GetComponent<CharacterController>();
            
            CanMove = true;
            _joystick = gamePlayUI.Joystick;
            _playerConfig = playerConfig;
            _gravity = 9.81f;
            _currentAttackTime = _attackTime;
        }

        private void Update()
        {
            var horizontalInput = -_joystick.Vertical;
            var verticalInput = _joystick.Horizontal;

            if (horizontalInput != 0 || verticalInput != 0 && CanMove)
            {
                if (!_playerConfig.IsMovementState() && _playerConfig.CanChangeState)
                    _playerConfig.ChangeToMovementState();
                
                _moveDirection = transform.forward;
                
                var rotation = new Vector3(horizontalInput, 0, verticalInput);
                transform.rotation = Quaternion.LookRotation(rotation);
            }
            else
            {
                if (!_playerConfig.IsIdleState() && _playerConfig.CanChangeState)
                    _playerConfig.ChangeToIdleState();
                _moveDirection = Vector3.zero;
            }

            if (_currentAttackTime > 0)
                _currentAttackTime -= Time.deltaTime;
        }

        private void FixedUpdate()
        {
            DoGravity(_controller.isGrounded);

            if (_playerConfig.IsMovementState() && CanMove)
                Move(_moveDirection);
        }

        public bool OnGround() => _controller.isGrounded;

        private void DoGravity(bool _isGrounded)
        {
            if (_isGrounded && _velocity.y < 1.9)
            {
                _velocity.y = -1;
            }
            _velocity.y -= _gravity * Time.fixedDeltaTime;
            _controller.Move(_velocity * Time.fixedDeltaTime);
        }

        private void Move(Vector3 direction) => _controller.Move(direction * _speed * Time.fixedDeltaTime);

        public void Jump()
        {
            if (_controller.isGrounded && _playerConfig.CanChangeState) {
                _velocity.y = _jumpForce;
                _playerConfig.ChangeToJumpState();
            }
        }

        public void Attack()
        {
            if (_playerConfig.CanChangeState && _currentAttackTime <= 0)
            {
                _playerConfig.ChangeToAttackState();
                _currentAttackTime = _attackTime;
            }
        }
    }
}