using nCloudyKingdom.Scripts.Game.GamePlay.StateMachine;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public abstract class BaseCharacterBehaviour : IState
    {
        protected readonly PlayerConfig playerConf;
        protected readonly Animator _animator;

        protected BaseCharacterBehaviour(PlayerConfig playerConf, Animator animator)
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