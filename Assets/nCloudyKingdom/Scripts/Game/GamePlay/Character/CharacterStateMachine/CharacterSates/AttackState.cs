using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class AttackState : BaseCharacterBehaviour
    {
        private float _attackTime = 1.5f;
        private float _currentAttackTime;
        private IAttackable _target;
        private Vector3 _enemyPosition;
        public AttackState(PlayerConf playerConf, Animator animator) : base(playerConf, animator) {}
        public override void OnEnter()
        {
            _currentAttackTime = 0.3f;
            HasTarget();
        }

        public override void Update()
        {
            if (_currentAttackTime <= 0)
            {
                if (HasTarget())
                {
                    _animator.SetTrigger("Attack");
                    _target.TakeDamage();
                }
                else
                {
                    playerConf.ChangeToFollowState();
                }
                _currentAttackTime = _attackTime;
            }
            else
            {
                _currentAttackTime -= Time.deltaTime;
            }
            
            if (_enemyPosition != Vector3.zero)
            {
                var dir = _enemyPosition - playerConf.transform.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                playerConf.transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }

        private bool HasTarget()
        {
            RaycastHit hit;
            Ray ray = new Ray(playerConf.RayPoint.position, playerConf.transform.forward);
            Debug.DrawRay(ray.origin, playerConf.transform.forward * 10);
            if (Physics.Raycast(ray, out hit, 5))
            {
                if (hit.collider.TryGetComponent(out IAttackable target))
                {
                    _enemyPosition = hit.transform.position;
                    _target = target;
                    
                    return true;
                }
            }

            _enemyPosition = Vector3.zero;
            return false;
        }
    }
}