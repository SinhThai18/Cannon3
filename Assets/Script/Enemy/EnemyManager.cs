using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public static event Action OnEnemyKilled; // Event khi enemy bị tiêu diệt

    public void KillEnemy()
    {
        gameObject.SetActive(false); // Trả enemy về pool
        OnEnemyKilled?.Invoke(); // Gọi event thông báo enemy bị tiêu diệt

        if (GameManager.Instance != null)
        {
            GameManager.Instance.EnemyKilled(); // Gọi GameManager để kiểm tra điều kiện thắng
        }
    }
}
