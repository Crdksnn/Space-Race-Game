using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    public void BulltetProperties(float speed, Vector3 direction)
    {
        this.direction = direction;
        this.speed = speed;
    }
    
}
