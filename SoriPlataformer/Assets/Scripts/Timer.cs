using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timerTotal = 90;
    private bool timerUp = false;
    public bool TimerUPGetSet
    {
        get => timerUp;
        set => timerUp = value;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (timerTotal > 0 && !timerUp)
        {
            timerTotal -= Time.deltaTime;
        }
        else timerUp = true;
    }
    private void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timerTotal / 60f);
        int seconds = Mathf.FloorToInt(timerTotal - minutes * 60f);

        string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);
        GUI.skin.label.fontSize = 50;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 10, 250, 100), timerString);
    }

    public float ReturnTimer()
    {
        return timerTotal;
    }
}
