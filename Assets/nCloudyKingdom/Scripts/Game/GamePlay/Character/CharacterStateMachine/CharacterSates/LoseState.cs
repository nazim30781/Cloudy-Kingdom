using System.Collections;
using Unity.XR.OpenVR;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class LoseState : BaseCharacterBehaviour
    {
        public LoseState(PlayerConf playerConf, Animator animator) : base(playerConf, animator) {}

        public override void OnEnter()
        {
            _animator.SetTrigger("Die");
            playerConf.StartCoroutine(Dead());
            playerConf.OnLose();
        }
        private IEnumerator Dead()
        {
            yield return new WaitForSeconds(2f);
            playerConf.Dead();
        }
    }
}