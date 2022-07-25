using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.S))
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
    }
}
