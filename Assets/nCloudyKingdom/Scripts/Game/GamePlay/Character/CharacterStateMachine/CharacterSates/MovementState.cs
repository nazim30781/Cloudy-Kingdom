using System.Collections;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class MovementState : BaseCharacterBehaviour
    {

        public MovementState(Player playerConf, Animator animator) : base(playerConf, animator) {}
        public override void OnEnter()
        {
            _animator.SetBool("Move", true);
        }

        public override void OnExit()
        {
            _animator.SetBool("Move", false);
        }
    }
}