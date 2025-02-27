using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemy();
        if (enemy != null) // Chỉ spawn nếu còn enemy trong pool
        {
            enemy.transform.position = spawnPoint.position;
        }
    }
}
