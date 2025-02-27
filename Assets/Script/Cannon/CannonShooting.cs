using UnityEngine;
using UnityEngine.EventSystems;

public class CannonShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab viên đạn
    public Transform firePoint; // Vị trí nòng súng
    public float bulletSpeed = 10f; // Tốc độ viên đạn

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Chuột trái được click! (Bắn)");
            Shoot();
        }

    }

    void Shoot()
    {
        // Lấy vị trí của chuột trên màn hình và chuyển thành vị trí trong thế giới game
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Đảm bảo z = 0 vì game 2D

        // Tính hướng từ nòng súng đến vị trí chuột
        Vector3 shootDirection = (mousePosition - firePoint.position).normalized;

        // Tạo viên đạn tại vị trí nòng súng và xoay nó theo hướng bắn
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Xoay viên đạn theo hướng bắn
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Gán vận tốc để viên đạn bay theo hướng tính được
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = shootDirection * bulletSpeed;
        }
    }
}
