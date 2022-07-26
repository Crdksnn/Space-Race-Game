using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private TextMeshProUGUI player1ScoreText;
    private static int player1Score;
    private bool isFinsihed = false;
    private Vector3 startPosition;
    
    void Start()
    {
        player1Score = 0;
        startPosition = transform.position;
    }
    
    void Update()
    {
        Move();
        FinishLine();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.S))
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        
    }

    private void FinishLine()
    {
        if (10.2 <= transform.position.y && !isFinsihed)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
            isFinsihed = true;
            RePosition();
        }
    }

    private void RePosition()
    {
        isFinsihed = false;
        transform.position = startPosition;
    }
    
}
