using System.Collections.Generic;
using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class AttackState : BaseCharacterBehaviour
    {
        public AttackState(PlayerConfig playerConf, Animator animator) : base(playerConf, animator) {}

        public override void OnEnter()
        {
            playerConf.CanChangeState = false;
            _animator.SetTrigger("Attack");
            ApplyDamage(CheckTargets());
        }

        private void ApplyDamage(List<EnemyHitBox> enemys)
        {
            foreach (var enemy in enemys)
            {
                Debug.Log("a");
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
    }
}