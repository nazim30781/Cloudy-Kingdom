using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public class PatrollState : EnemyBaseBehaviour
    {
        private EnemyPatrollerHandler _enemyPatrollerHandler;

        private float _currentTime;
        private float _waitTime = 3;

        public PatrollState(Enemy enemy, Animator animator, EnemyPatrollerHandler enemyPatrollerHandler) : base(enemy, animator)
        {
            _enemyPatrollerHandler = enemyPatrollerHandler;
        }

        public override void OnEnter()
        {
            _animator.SetBool("Look", true);
            _currentTime = _waitTime;
            Check();
        }

        public override void Update()
        {
            if (_currentTime >= 0)
            {
                _currentTime -= Time.deltaTime;
                Check();
            }
                
            else
                _enemyPatrollerHandler.StartMove();
            
        }

        public override void OnExit()
        {
            _animator.SetBool("Look", false);
        }

        private bool Check()
        {
            Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 5.5f);

            foreach (var collider in colliders)
            {
                if (collider.GetComponent<PlayerConf>())
                {
                    _enemyPatrollerHandler.StartFollow();
                    return true;
                }
            }
            return false;
        }
        
    }
}