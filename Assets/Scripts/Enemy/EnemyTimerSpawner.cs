using System.Collections;
using ShootEmUp;
using UnityEngine;

internal class EnemyTimerSpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1F);
            _enemyPool.SpawnEnemy();
        }
    }
}
