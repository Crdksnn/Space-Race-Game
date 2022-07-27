using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 3;
    private Vector2 direction = new Vector2(1,0);
    
    private Transform player1;
    private Transform player2;
    
    private static string Player1 = "Player1";
    private static string Player2 = "Player2";

    //Player Boundries
    private Vector2 leftUp = Vector2.zero;
    private Vector2 leftDown = Vector2.zero;
    private Vector2 rightUp = Vector2.zero;
    private Vector2 rightDown = Vector2.zero;

    private List<Vector2> player1Bounds = new List<Vector2>();

    void Start()
    {
        if(GameObject.FindWithTag(Player1))
            player1 = GameObject.FindWithTag(Player1).transform;
        
        if(GameObject.FindWithTag(Player2))
            player2 = GameObject.FindWithTag(Player2).transform;
    }
    
    void Update()
    {
        Player1BoundsClear();
        Player1Boundries();
        
        var pos = (Vector2)transform.position;
        var movement = direction * speed * Time.deltaTime;
        var newPos = pos + movement;
        
        Debug.DrawLine(transform.position,newPos,Color.red);
        
        if (FindIntersect(pos, pos + movement))
        {
            player1.GetComponent<Player1Settings>().RePosition();
            Destroy(gameObject);
        }
        
        transform.position = newPos;
        
    }

    private bool FindIntersect(Vector2 bulletCenter, Vector2 bulletMovement)
    {

        for (int i = 0; i < player1Bounds.Count; i += 2)
        {
            if (Math2d.LineSegmentsIntersection(bulletCenter, bulletMovement, player1Bounds[i], player1Bounds[i + 1]))
            {
                return true;
            }
        }

        return false;
    }
    
    private void Player1BoundsClear()
    {
        player1Bounds.Clear();
    }
    
    private void Player1Boundries()
    {
        leftUp.x = player1.transform.position.x - player1.localScale.x / 2;
        leftUp.y = player1.transform.position.y + player1.localScale.y / 2;

        leftDown.x = player1.transform.position.x - player1.localScale.x / 2;
        leftDown.y = player1.transform.position.y - player1.localScale.y / 2;

        rightUp.x = player1.transform.position.x + player1.localScale.x / 2;
        rightUp.y = player1.transform.position.y + player1.localScale.y / 2;

        rightDown.x = player1.transform.position.x + player1.localScale.x / 2;
        rightDown.y = player1.transform.position.y - player1.localScale.y / 2;
        
        Debug.DrawLine(leftUp,leftDown,Color.blue);
        Debug.DrawLine(rightUp,rightDown,Color.blue);
        Debug.DrawLine(leftUp,rightUp,Color.blue);
        
        player1Bounds.Add(leftUp);
        player1Bounds.Add(leftDown);
        player1Bounds.Add(rightUp);
        player1Bounds.Add(rightDown);
        player1Bounds.Add(leftUp);
        player1Bounds.Add(rightUp);
        
    }

    public void BulletDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    
}
