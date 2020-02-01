using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        movement.x = 0.1f;
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
    }
}
