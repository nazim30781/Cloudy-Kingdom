using nCloudyKingdom.Scripts.Game.GamePlay.StateMachine;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Character.CharacterStateMachine.CharacterSates
{
    public abstract class BaseCharacterBehaviour : IState
    {
        protected readonly Player _player;
        protected readonly Animator _animator;

        protected BaseCharacterBehaviour(Player player, Animator animator)
        {
            _player = player;
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