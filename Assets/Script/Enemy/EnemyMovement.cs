using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 moveDirection = Vector2.right;


    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        moveDirection *= -1;
        transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
