using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public bool isAlive = true;
    private int healthPoints = 10;
    private float healthTimer = 0.5f;
    [SerializeField]
    private int layerInt;
    SpriteRenderer sprite;
    [SerializeField]
    private Transform respawnPosition;
    private int lives = 3;
    private float timeReset = 2f;
    private bool death = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        if(timeReset > 0 && death)
        {
            timeReset -= Time.deltaTime;
        }
        else if (timeReset <= 0 && healthPoints <= 0)
        {
            RestartPlayer();
            timeReset = 2f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == layerInt)
        {
            if(healthTimer > 0)
            {
                healthTimer -= Time.deltaTime;
            }
            else if (healthTimer <= 0)
            {
                healthPoints -= 10;
                if(healthPoints <= 0 && lives > 0)
                {
                    lives--;
                    Debug.Log(lives);
                    playerLose();
                }
                else if (lives <= 0)
                {
                    isAlive = false;
                }
                healthTimer = 0.5f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            Debug.Log("Win");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {


        }
    }
    private void playerLose()
    {
        sprite.color = Color.red;
        death = true;
        playerMovement.DisableMovement();
    }
    public void RestartPlayer()
    {
        gameObject.transform.position = respawnPosition.position;
        sprite.color = Color.white;
        healthPoints = 100;
        death = false;
        playerMovement.EnableMovement();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == layerInt)
        {

        }
    }
   
}
