using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public class JumpState : BaseCharacterBehaviour
    {
        private PlayerController _controller;
        private bool _canChange = true;

        public JumpState(Player playerConf, Animator animator, PlayerController controller) : base(playerConf,
            animator)
        {
            _controller = controller;
        }

        public override void OnEnter()
        {
            playerConf.CanChangeState = false;
            
            _animator.SetTrigger("Jump");
            _controller.StartCoroutine(CanChange());
            _canChange = false;
        }

        private IEnumerator CanChange()
        {
            yield return new WaitForSeconds(0.5f);
            _canChange = true;
        }

        public override void Update()
        {
            if (_controller.OnGround() && _canChange)
            {
                playerConf.CanChangeState = true;
            }
        }

        public override void OnExit()
        {
            playerConf.CanChangeState = true;
        }
    }
}