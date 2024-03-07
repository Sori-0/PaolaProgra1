using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RB2D;
    private float movespeed = 5;
    private float JumpForce = 7;
    private float DoubleJump = 0;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    private int numLayer = 7;
    void Start()
    {

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(horizontal * movespeed, RB2D.velocity.y);
        RB2D.velocity = velocity;
        if (DoubleJump < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                animator.SetBool("IsJumping", true);
                DoubleJump++;
            }
        }
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IsRunning", true);
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IsRunning", true);
        }
        else if (horizontal == 0)
        {
            animator.SetBool("IsRunning", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == numLayer)
        {
            animator.SetBool("IsJumping", false);
            DoubleJump = 0;
        }
    }
    public void DisableMovement()
    {
        movespeed = 0;
        JumpForce = 0;
    }
    public void EnableMovement()
    {
        movespeed = 5;
    }
}
