using nCloudyKingdom.Scripts.Game.GamePlay.Enemys;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class FollowState : BaseCharacterBehaviour
    {
        private PlayerFollowHandler _handler;

        public FollowState(PlayerConf player, Animator animator, PlayerFollowHandler followHandler) : base(player,
            animator)
        {
            _handler = followHandler;
        }

        public override void OnEnter()
        {
            _animator.SetBool("Move", true);
            Debug.Log("enter");
        }

        public override void Update()
        {
            _handler.Follow();
        }

        public override void OnExit()
        {
            _animator.SetBool("Move",  false);
        }
    }
}