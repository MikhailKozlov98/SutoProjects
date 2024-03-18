using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool _enemyPool;

        [SerializeField]
        private BulletSystem _bulletSystem;
        
        private readonly HashSet<GameObject> m_activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                EnemyCharacter enemy = this._enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (this.m_activeEnemies.Add(enemy.gameObject))
                    {
                        enemy.GetHpComponent().HpEmpty += this.OnDestroyed;
                        enemy.GetEnemyAttack().OnFire += this.OnFire;
                    }    
                }
            }
        }

        private void OnDestroyed(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                EnemyCharacter enemyCharacter = enemy.GetComponent<EnemyCharacter>();

                enemyCharacter.GetHpComponent().HpEmpty -= this.OnDestroyed;
                enemyCharacter.GetEnemyAttack().OnFire -= this.OnFire;

                _enemyPool.UnspawnEnemy(enemyCharacter);
            }
        }

        private void OnFire(GameObject enemy, Vector2 position, Vector2 direction, BulletConfig bulletConfig)
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = position,
                velocity = direction * 2.0f
            });
        }
    }
}