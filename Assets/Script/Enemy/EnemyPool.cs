using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyType
{
    public GameObject prefab;
    public int poolSize;
    public Transform spawnPoint; // Vị trí spawn riêng cho từng loại
}

public class EnemyPool : MonoBehaviour
{
    public List<EnemyType> enemyTypes; // Danh sách các loại enemy

    private Dictionary<GameObject, List<GameObject>> enemyPools = new Dictionary<GameObject, List<GameObject>>();

    void Start()
    {
        // Khởi tạo pool cho từng loại enemy
        foreach (var enemyType in enemyTypes)
        {
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < enemyType.poolSize; i++)
            {
                GameObject enemy = Instantiate(enemyType.prefab);
                enemy.SetActive(false);
                pool.Add(enemy);
            }

            enemyPools[enemyType.prefab] = pool;
        }
    }

    // Lấy enemy từ pool theo loại enemy
    public GameObject GetEnemy(GameObject enemyPrefab)
    {
        if (enemyPools.ContainsKey(enemyPrefab))
        {
            foreach (GameObject enemy in enemyPools[enemyPrefab])
            {
                if (!enemy.activeInHierarchy)
                {
                    enemy.SetActive(true);
                    return enemy;
                }
            }
        }

        // Nếu pool hết enemy, return null
        return null;
    }

    // Hàm trả enemy về pool (khi enemy chết)
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
