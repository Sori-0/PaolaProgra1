using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timerTotal = 90;
    bool timerUP = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (timerTotal > 0)
        {
            timerTotal -= Time.deltaTime;
        }
        else
            timerUP = true;
        timerTotal -= Time.deltaTime;
        Debug.Log(timerTotal);
    }
}
