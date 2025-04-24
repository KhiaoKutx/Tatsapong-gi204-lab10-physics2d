using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    Vector2 moveInput;
    
    float move;
    [SerializeField] float speed;

    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;
    
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        rb2d.AddForce(moveInput * speed);
        
        //jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("jump!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
