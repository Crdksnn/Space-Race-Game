using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    
    private Transform player1;
    private Transform player2;
    
    private static string Player1 = "Player1";
    private static string Player2 = "Player2";
    
    void Start()
    {
        if(GameObject.FindWithTag(Player1))
            player1 = GameObject.FindWithTag(Player1).transform;
        
        if(GameObject.FindWithTag(Player2))
            player2 = GameObject.FindWithTag(Player2).transform;
    }
    
    void Update()
    {

        if (player1 != null)
        {
            float distance = Vector3.Distance(player1.position, transform.position);
            if (distance <= .35f)
            {
                Destroy(gameObject);
                player1.GetComponent<Player1Settings>().RePosition();
            }
                
        }
        
        if (player2 != null)
        {
            float distance = Vector3.Distance(player2.position, transform.position);
            if (distance <= .35f)
            {
                Destroy(gameObject);
                player2.GetComponent<Player2Settings>().RePosition();
            }
                
        }
        
        transform.position += speed * direction * Time.deltaTime;
        
        Destroy(gameObject, 5f);
    }

    public void BulletProperties(float speed, Vector3 direction)
    {
        this.direction = direction;
        this.speed = speed;
    }
    
}
