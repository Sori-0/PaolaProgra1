using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public bool isAlive = true ;
    [SerializeField]
    private float healthTimer = 0.5f;
    [SerializeField]
    private int layerInt = 7;
    [SerializeField]
    Transform respawnPoint;
    [SerializeField]
    private int healthPoints = 100;
    SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerInt)
        {
            if (healthTimer > 0)
            {
                healthTimer -= Time.deltaTime;
            }
            else if (healthTimer <= 0 && isAlive)
            {
                healthPoints--;
                if (healthPoints <= 0)
                {
                    isAlive = false;
                    Debug.Log("Perdiste");
                }
                healthTimer = 0.5f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Win")
        {
            Debug.Log("Ganaste");
        }
    }
    private void PlayerLose()
    {
        sprite.color = Color.red;
    }
    public void RestartPlayer()
    {
        gameObject.transform.position = respawnPoint.position;
        sprite.color = Color.white;
        healthPoints = 10;
        isAlive = true;
    }
}
