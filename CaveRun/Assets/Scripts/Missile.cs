using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody rb;
    float MoveSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Back()
    {
        rb.velocity = new Vector2(5f, 1f);
        rb.AddForce(Vector2.right * Vector2.down * MoveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            Destroy(gameObject);
        }
    }
}