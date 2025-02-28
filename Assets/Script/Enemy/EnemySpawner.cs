using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, spawnInterval);
    }

    void SpawnEnemies()
    {
        foreach (var enemyType in enemyPool.enemyTypes)
        {
            GameObject enemy = enemyPool.GetEnemy(enemyType.prefab);
            if (enemy != null)
            {
                enemy.transform.position = enemyType.spawnPoint.position;
            }
        }
    }
}
