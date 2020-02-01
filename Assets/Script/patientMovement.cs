using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patientMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;

    public enum Direction{Left,Right}; 
    public Direction MovementDirection;

    Vector2 movement;

    void Start(){
        if (MovementDirection==Direction.Left){
            Vector3 scaleChange = new Vector3(transform.localScale.x*-1, transform.localScale.y,transform.localScale.z);
            movement.x = -1f;
            transform.localScale=scaleChange;
        }else{
            movement.x = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * moveSpeed *Time.fixedDeltaTime);
    }
}
