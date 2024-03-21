using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject parent;
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            parent.SetActive(false);
            PointsManager.instance.AddPoints(5);
        }
    }
}
