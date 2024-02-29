using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RB2D;
    private float movespeed = 5;
    private float JumpSpeed = 7;
    private float DoubleJump = 0;
    private int numLayer = 6;
    void Start()
    {

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(horizontal * movespeed, RB2D.velocity.y);
        RB2D.velocity = velocity;
        //Esto nos da ´que tanto va a aumentar gracias a nuestra velocidad
        if (DoubleJump < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB2D.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);

                DoubleJump++;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == numLayer)
        {
            DoubleJump = 0;
        }
    }

}
