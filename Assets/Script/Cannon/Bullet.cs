using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyManager>().KillEnemy(); // Gọi hàm xử lý kill
            Destroy(gameObject);
        }
    }
}
