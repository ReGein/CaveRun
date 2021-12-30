using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    Rigidbody rb;
    public float MoveSpeed = 400f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(1f, rb.velocity.y);
        rb.AddForce(Vector2.right * MoveSpeed);
    }
}
