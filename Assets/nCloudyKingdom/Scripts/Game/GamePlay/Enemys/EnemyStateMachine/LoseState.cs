using System.Collections;
using nCloudyKingdom.Scripts.Utils;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public class LoseState : EnemyBaseBehaviour
    {
        public LoseState(Enemy enemy, Animator animator) : base(enemy, animator) {}

        public override void OnEnter()
        {
            _animator.SetTrigger("Loose");
            _enemy.StartCoroutine(Dead());
        }

        IEnumerator Dead()
        {
            yield return new WaitForSeconds(1);
            _enemy.Lose();
        }
    }
}