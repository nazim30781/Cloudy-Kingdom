using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace nCloudyKingdom.Scripts.Game.GamePlay.Enemys
{
    public class EnemyPatrollerHandler : MonoBehaviour
    {
        private List<Transform> _targets;
        private Transform _currentTarget;
        private int _currentTargetNumber;
        private int _maxTargetNumber;

        private NavMeshAgent _agent;
        private IPatroller _patroller;

        public void Initialize(List<Transform> targets, NavMeshAgent agent, IPatroller patroller)
        {
            _agent = agent;
            _patroller = patroller;
            _targets = targets;
            _currentTargetNumber = 0;
            _maxTargetNumber = _targets.Count - 1;
            _currentTarget = _targets[_currentTargetNumber];
            
            _patroller.ChangeToPatrolState();
        }

        private Vector3 GetDestination()
        {
            Ray ray = new Ray(_currentTarget.position, Vector3.down);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, Vector3.down);
            Physics.Raycast(ray, out hit);

            if (_currentTargetNumber + 1 <= _maxTargetNumber)
                _currentTargetNumber += 1;
            else
                _currentTargetNumber = 0;
            _currentTarget = _targets[_currentTargetNumber];

            return hit.point;
        }

        public void StartFollow()
        {
            _patroller.StartFollow();
        }

        public void StartAttack()
        {
            _patroller.ChangeToAttackState();
        }

        public bool HasPath()
        {
            return _agent.hasPath;
        }

        public void StartMove()
        {
            _agent.SetDestination(GetDestination());
            _patroller.MoveNextTarget();
        }

        public void StartPatrol()
        {
            _patroller.ChangeToPatrolState();
        }
    }
}