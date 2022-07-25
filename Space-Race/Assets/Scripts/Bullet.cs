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
    private Transform player;
    
    void Start()
    {
        if(GameObject.FindWithTag("Player1"))
            player = GameObject.FindWithTag("Player1").transform;
    }
    
    void Update()
    {

        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= .45f)
                Destroy(player.gameObject);
        }
        
        transform.position += speed * direction * Time.deltaTime;
    }

    public void BulltetProperties(float speed, Vector3 direction)
    {
        this.direction = direction;
        this.speed = speed;
    }
    
}
