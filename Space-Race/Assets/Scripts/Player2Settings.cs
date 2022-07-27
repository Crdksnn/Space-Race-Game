using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2Settings : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private TextMeshProUGUI player2ScoreText;
    private static int player2Score;
    private bool isFinsihed = false;
    private Vector3 startPosition;
    
    void Start()
    {
        player2Score = 0;
        startPosition = transform.position;
    }
    
    void Update()
    {
        Move();
        FinishLine();
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.DownArrow))
            transform.position -= Vector3.down * moveSpeed * Time.deltaTime;
        
    }

    private void FinishLine()
    {
        if (10.2 <= transform.position.y && !isFinsihed)
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
            isFinsihed = true;
            RePosition();
        }
    }

    public void RePosition()
    {
        if(isFinsihed)
            isFinsihed = false;
        
        transform.position = startPosition;
    }
    
}
