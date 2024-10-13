using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class IdleState : BaseCharacterBehaviour
    {
        public IdleState(Player player, Animator animator) : base(player, animator) {}
        public override void OnEnter()
        {
            _animator.SetBool("Idle", true);
        }

        public override void OnExit()
        {
            _animator.SetBool("Idle", false);
        }
    }
}