using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public abstract class Enemy : MonoBehaviour
    {
        public EnemyConfig Config;
        
        protected Animator _animator;
        protected StateMachine.StateMachine _stateMachine;
        

        public Transform RayPoint;

        public event Action<Enemy> Losed; 

        public abstract void Initialize();

        protected virtual void Update()
        {
            _stateMachine.CurrentState.Update();
            print(_stateMachine.CurrentState);
        }
        public virtual void AfterAttackAction() {}
        public virtual void BaseBehaviour() {}
        public virtual void Lose() {}
        public virtual void OnLose() => Losed?.Invoke(this);
    }
}