using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(!player.isAlive)
        {
            player.RestartPlayer();
        }
    }
}
