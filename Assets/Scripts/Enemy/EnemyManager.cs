using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemyPool _enemyPool;

        // private readonly HashSet<GameObject> m_activeEnemies = new();

        // internal void EnemySpawn()
        // {
        //     EnemyCharacter enemy = this._enemyPool.SpawnEnemy();
        //     if (enemy != null)
        //     {
        //         if (this.m_activeEnemies.Add(enemy.gameObject))
        //         {
        //             enemy.GetHpComponent().HpEmpty += this.OnDestroyed;
        //         }
        //     }
        // }


        // private void OnDestroyed(GameObject enemy)
        // {
        //     if (m_activeEnemies.Remove(enemy))
        //     {
        //         EnemyCharacter enemyCharacter = enemy.GetComponent<EnemyCharacter>();

        //         enemyCharacter.GetHpComponent().HpEmpty -= this.OnDestroyed;

        //         _enemyPool.UnspawnEnemy(enemyCharacter);
        //     }
        // }
    }
}