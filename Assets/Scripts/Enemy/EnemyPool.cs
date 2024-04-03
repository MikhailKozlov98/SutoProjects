using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Spawn")]
        [SerializeField]
        private EnemyPositions _enemyPositions;

        [SerializeField] private Character _player;
        [SerializeField] private BulletSystem _bulletSystem;

        [SerializeField] private Transform _worldTransform;

        [Header("Pool")]
        [SerializeField] private Transform _container;

        [SerializeField] private EnemyCharacter _prefab;

        private GameObjectPool<EnemyCharacter> _pool;
        private readonly HashSet<GameObject> m_activeEnemies = new();


        // private readonly Queue<EnemyCharacter> enemyPool = new();

        private void Awake()
        {
            _pool = new GameObjectPool<EnemyCharacter>(_prefab);
            // for (int i = 0; i < 7; i++)
            // {
            //     EnemyCharacter enemy = Instantiate(_prefab, _container);
            //     enemyPool.Enqueue(enemy);
            // }
        }

        internal EnemyCharacter SpawnEnemy()
        {
            EnemyCharacter enemy = _pool.Create(_worldTransform);

            // if (!enemyPool.TryDequeue(out EnemyCharacter enemy))
            // {
            //     return null;
            // }

            enemy.transform.SetParent(_worldTransform);

            Transform spawnPosition = _enemyPositions.RandomSpawnPosition();
            enemy.transform.position = spawnPosition.position;

            Transform attackPosition = _enemyPositions.RandomAttackPosition();
            enemy.SetDestination(attackPosition.position);

            enemy.SetTarget(_player);
            enemy.SetBulletSystem(_bulletSystem);

            m_activeEnemies.Add(enemy.gameObject);
            enemy.GetHpComponent().HpEmpty += UnspawnEnemy;

            return enemy;
        }

        internal void UnspawnEnemy(GameObject enemyObj)
        {
            m_activeEnemies.Remove(enemyObj);
            _pool.Despawn(enemyObj.GetComponent<EnemyCharacter>(), _container);

            // enemy.transform.SetParent(_container);
            // enemyPool.Enqueue(enemy);
        }
    }
}