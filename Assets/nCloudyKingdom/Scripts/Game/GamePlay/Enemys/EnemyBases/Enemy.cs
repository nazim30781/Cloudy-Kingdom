using System;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public abstract class Enemy : MonoBehaviour
    {
        public EnemyConfig Config;
        
        protected Animator _animator;
        protected StateMachine.StateMachine _stateMachine;
        

        public Transform RayPoint;

        public event Action<Enemy, int> Losed; 

        public abstract void Initialize();

        protected virtual void Update()
        {
            _stateMachine.CurrentState.Update();
        }
        public virtual void AfterAttackAction() {}
        public virtual void BaseBehaviour() {}
        public virtual void Lose() {}
        public virtual void OnLose() => Losed?.Invoke(this, Config.Price);
    }
}