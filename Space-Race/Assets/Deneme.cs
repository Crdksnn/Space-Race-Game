using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public Transform circle;
    public float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += speed * Time.deltaTime * Vector3.right;
        
        float distance = Vector3.Distance(transform.position, circle.position);

        if (distance <= 1)
            Destroy(circle.gameObject);
    }
}
