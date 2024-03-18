using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField]
        private Character _player;

        [SerializeField]
        private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private EnemyCharacter _prefab;

        private readonly Queue<EnemyCharacter> enemyPool = new();
        
        private void Awake()
        {
            for (int i = 0; i < 7; i++)
            {
                EnemyCharacter enemy = Instantiate(this._prefab, this._container);
                this.enemyPool.Enqueue(enemy);
            }
        }

        internal EnemyCharacter SpawnEnemy()
        {
            if (!this.enemyPool.TryDequeue(out EnemyCharacter enemy))
            {
                return null;
            }

            enemy.transform.SetParent(this._worldTransform);

            Transform spawnPosition = this._enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            Transform attackPosition = this._enemyPositions.RandomAttackPosition();
            enemy.SetDestination(attackPosition.position);

            enemy.SetTarget(this._player);
            return enemy;
        }

        internal void UnspawnEnemy(EnemyCharacter enemy)
        {
            enemy.transform.SetParent(this._container);
            this.enemyPool.Enqueue(enemy);
        }
    }
}