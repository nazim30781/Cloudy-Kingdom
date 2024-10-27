using System.Collections;
using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class AttackState : BaseCharacterBehaviour
    {
        private PlayerController _controller;

        public AttackState(PlayerConfig playerConf, Animator animator, PlayerController controller) : base(playerConf,
            animator)
        {
            _controller = controller;
        }

        public override void OnEnter()
        {
            _controller.CanMove = false;
            playerConf.StartCoroutine(CanMove());
            
            playerConf.CanChangeState = false;
            
            _animator.SetTrigger("Attack");
            
            ApplyDamage(CheckTargets());
        }

        private void ApplyDamage(List<EnemyHitBox> enemys)
        {
            foreach (var enemy in enemys)
            {
                enemy.TakeDamage();
            }
            
            playerConf.CanChangeState = true;
        }

        private List<EnemyHitBox> CheckTargets()
        {
            Collider[] targets = Physics.OverlapSphere(playerConf.AttackPoint.position, 3.5f);

            List<EnemyHitBox> _enemys = new List<EnemyHitBox>();

            foreach (var taret in targets)
            {
                if (taret.TryGetComponent(out EnemyHitBox hitBox))
                {
                    _enemys.Add(hitBox);
                }
            }
            return _enemys;
        }

        private IEnumerator CanMove()
        {
            yield return new WaitForSeconds(0.35f);
            _controller.CanMove = true;
        }
    }
}