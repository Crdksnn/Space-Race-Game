using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if(-2 <= transform.position.y)
            transform.position += new Vector3(0, -.1f, 0) * speed * Time.deltaTime;
    }
}
