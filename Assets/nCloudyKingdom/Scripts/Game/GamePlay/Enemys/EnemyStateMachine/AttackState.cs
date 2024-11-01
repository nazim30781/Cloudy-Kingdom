﻿using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public class AttackState : EnemyBaseBehaviour
    {
        private float _attackTime = 1.5f;
        private float _currentAttackTime;
        private PlayerBody _playerBody;
        private Transform _target;
        private EnemyAttackHandler _handler;

        public AttackState(Enemy enemy, Animator animator, EnemyAttackHandler handler) : base(enemy, animator)
        {
            _handler = handler;
        }

        public override void OnEnter()
        {
            _currentAttackTime = 0.3f;
            if (HasTarget())
                _target = _playerBody.transform;
            _attackTime = _enemy.Config.AttackTime;
        }

        public override void Update()
        {
            if (_target)
            {
                var dir = _target.transform.position - _enemy.transform.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                _enemy.transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            
            if (_currentAttackTime <= 0 && HasTarget())
            {
                _handler.Attack(_playerBody);
                _animator.SetTrigger("Attack");
                _currentAttackTime = _attackTime;
            }
            else
                _currentAttackTime -= Time.deltaTime;
            
            if (!HasTarget())
                _enemy.BaseBehaviour();
        }

        private bool HasTarget()
        {
            RaycastHit hit;
            Ray ray = new Ray(_enemy.RayPoint.position, _enemy.transform.forward);
            if (Physics.Raycast(ray, out hit, _enemy.Config.AttackDistance))
            {
                if (hit.collider.TryGetComponent(out PlayerBody body))
                {
                    _playerBody = body;
                    return true;
                }
            }
            return false;
        }

    }
}