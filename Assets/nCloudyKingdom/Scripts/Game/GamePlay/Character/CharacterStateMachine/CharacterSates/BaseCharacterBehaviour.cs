using nCloudyKingdom.Scripts.Game.GamePlay.StateMachine;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public abstract class BaseCharacterBehaviour : IState
    {
        protected readonly PlayerConf playerConf;
        protected readonly Animator _animator;

        protected BaseCharacterBehaviour(PlayerConf playerConf, Animator animator)
        {
            this.playerConf = playerConf;
            _animator = animator;
        }
        
        public virtual void OnEnter()
        {
            
        }

        public virtual void Update()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}