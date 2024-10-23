using nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine;
using UnityEngine;
using AttackState = nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine.AttackState;
using IdleState = nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine.IdleState;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public abstract class Enemy : MonoBehaviour
    {
        protected Animator _animator;
        protected StateMachine.StateMachine _stateMachine;

        public Transform RayPoint;

        public abstract void Initialize();

        protected virtual void Update() => _stateMachine.CurrentState.Update();
        public virtual void AfterAttackAction() {}
        public virtual void BaseBehaviour() {}
        public virtual void Lose() {}
        public virtual void OnLose() {}
    }
}