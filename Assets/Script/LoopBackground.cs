using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public float speed = 2f;  // Tốc độ di chuyển background
    public GameObject background2;  // Background thứ hai để tạo hiệu ứng lặp

    private float height;  // Chiều cao của background

    void Start()
    {
        // Lấy chiều cao của background từ SpriteRenderer
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Di chuyển cả hai background xuống theo trục Y
        transform.position += Vector3.down * speed * Time.deltaTime;
        background2.transform.position += Vector3.down * speed * Time.deltaTime;

        // Nếu background 1 ra khỏi màn hình, di chuyển nó lên trên background 2
        if (transform.position.y <= -height)
        {
            transform.position = new Vector3(transform.position.x, background2.transform.position.y + height, transform.position.z);
        }

        // Nếu background 2 ra khỏi màn hình, di chuyển nó lên trên background 1
        if (background2.transform.position.y <= -height)
        {
            background2.transform.position = new Vector3(background2.transform.position.x, transform.position.y + height, background2.transform.position.z);
        }
    }
}
