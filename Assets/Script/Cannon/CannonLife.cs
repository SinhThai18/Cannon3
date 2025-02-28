using UnityEngine;
using UnityEngine.UI;

public class CannonLife : MonoBehaviour
{
    public int lives = 3;
    public Image[] liveUI;
    private Animator anim; // Thêm biến Animator

    void Start()
    {
        anim = GetComponent<Animator>(); // Lấy Animator từ Cannon
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name);
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy chạm Cannon");
            collision.gameObject.SetActive(false);
            lives--;

            // Cập nhật giao diện mạng sống
            for (int i = 0; i < liveUI.Length; i++)
            {
                liveUI[i].enabled = i < lives;
            }

            if (GameManager.Instance != null)
            {
                GameManager.Instance.CannonHit(); // Báo cho GameManager biết Cannon bị mất mạng
            }

            if (lives <= 0)
            {
                Debug.Log("Cannon bị phá hủy!");
                anim.SetTrigger("Explode"); // Kích hoạt animation Explode
                Invoke("DestroyCannon", 0.6f); // Chờ 0.6s rồi hủy Cannon
            }
        }
    }

    void DestroyCannon()
    {
        Destroy(gameObject);
    }
}
