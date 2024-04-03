using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    internal class EnemyCharacter : Character
    {
        [SerializeField] private EnemyAttackAgent _enemyAttackAgent;
        [SerializeField] private EnemyMoveAgent _enemyMoveAgent;

        internal void SetDestination(Vector2 destinatation)
        {
            _enemyMoveAgent.SetDestination(destinatation);
        }

        internal bool IsReached()
        {
            return _enemyMoveAgent.IsReached;
        }

        internal void SetTarget(Character target)
        {
            _enemyAttackAgent.SetTarget(target);
        }

        internal void SetBulletSystem(BulletSystem bulletSystem)
        {
            _enemyAttackAgent.SetBulletSystem(bulletSystem);
        }
    }
}
