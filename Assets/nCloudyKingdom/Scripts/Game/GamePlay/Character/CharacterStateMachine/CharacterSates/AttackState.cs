using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class AttackState : BaseCharacterBehaviour
    {
        private float _attackTime = 1.5f;
        private float _currentAttackTime;

        private Enemy _enemy;
        public AttackState(Player player, Animator animator) : base(player, animator) {}
        public override void OnEnter()
        {
            _currentAttackTime = _attackTime;
            _animator.SetTrigger("Attack");

            HasTarget();
        }

        public override void Update()
        {
            if (_enemy)
            {
                var dir = _enemy.transform.position - _player.transform.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                _player.transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            if (_currentAttackTime <= 0)
            {
                _animator.SetTrigger("Attack");
                if (HasTarget())
                {
                    _enemy.TakeDamage();
                }
                else
                {
                    _player.ChangeToIdleState();
                }
                _currentAttackTime = _attackTime;
            }
            else
            {
                _currentAttackTime -= Time.deltaTime;
            }
        }

        private bool HasTarget()
        {
            RaycastHit hit;
            Ray ray = new Ray(_player.RayPoint.position, _player.transform.forward);
            Debug.DrawRay(ray.origin, _player.transform.forward * 10);
            if (Physics.Raycast(ray, out hit, 5))
            {
                if (hit.collider.TryGetComponent(out IAttackable enemy))
                {
                    _enemy = hit.collider.GetComponent<Enemy>();
                    
                    return true;
                }
            }
            return false;
        }
    }
}