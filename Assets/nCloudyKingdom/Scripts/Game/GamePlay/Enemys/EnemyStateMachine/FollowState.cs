using nCloudyKingdom.Scripts.Game.GamePlay.Character;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys.EnemyStateMachine
{
    public class FollowState : EnemyBaseBehaviour
    {
        private Transform _target;
        private NavMeshAgent _agent;
        private EnemyPatrollerHandler _enemyPatrollerHandler;

        private float _currentTime;
        private float _checkTime = 1;

        public FollowState(Enemy enemy, Animator animator, NavMeshAgent agent, EnemyPatrollerHandler enemyPatrollerHandler) : base(enemy, animator)
        {
            _agent = agent;
            _enemyPatrollerHandler = enemyPatrollerHandler;
        }

        public override void OnEnter()
        {
            _animator.SetBool("Walk", true);
            CheckTarget();
            _currentTime = _checkTime;
        }

        public  override void Update()
        {
            var dir = _target.position - _enemy.transform.position;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            _enemy.transform.rotation = Quaternion.Euler(0, angle, 0);

            _agent.SetDestination(_target.position);

            if (dir.magnitude <= 2.9f)
                _enemyPatrollerHandler.StartAttack();

            if (_currentTime <= 0)
            {
                CheckTarget();
                _currentTime = _checkTime;
            }
            else
                _currentTime -= Time.deltaTime;
        }

        public override void OnExit()
        {
            _animator.SetBool("Walk",  false);
        }

        private bool CheckTarget()
        {
            Collider[] colliders = Physics.OverlapSphere(_enemy.transform.position, 6);

            foreach (var collider in colliders)
            {
                if (collider.GetComponent<PlayerConf>())
                {
                    _target = collider.transform;
                    return true;
                }
            }
            _enemy.AfterAttackAction();
            return false;
        }
    }
}