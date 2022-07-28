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

    //Player1 Boundries
    private Vector2 player1LeftUp = Vector2.zero;
    private Vector2 player1LeftDown = Vector2.zero;
    private Vector2 player1RightUp = Vector2.zero;
    private Vector2 player1RightDown = Vector2.zero;

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
        
        Debug.DrawLine(transform.position + new Vector3((transform.localScale.x / 2) * MathF.Sign(direction.x), 0,0),newPos,Color.red);
        
        if (FindIntersect(pos, pos + movement))
        {
            player1.GetComponent<Player1Settings>().RePosition();
            Destroy(gameObject);
        }
        
        if(gameObject != null)
            Destroy(gameObject,5f);
        
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
        player1LeftUp.x = player1.transform.position.x - player1.localScale.x / 2;
        player1LeftUp.y = player1.transform.position.y + player1.localScale.y / 2;

        player1LeftDown.x = player1.transform.position.x - player1.localScale.x / 2;
        player1LeftDown.y = player1.transform.position.y - player1.localScale.y / 2;

        player1RightUp.x = player1.transform.position.x + player1.localScale.x / 2;
        player1RightUp.y = player1.transform.position.y + player1.localScale.y / 2;

        player1RightDown.x = player1.transform.position.x + player1.localScale.x / 2;
        player1RightDown.y = player1.transform.position.y - player1.localScale.y / 2;
        
        Debug.DrawLine(player1LeftUp,player1LeftDown,Color.blue);
        Debug.DrawLine(player1RightUp,player1RightDown,Color.blue);
        Debug.DrawLine(player1LeftUp,player1RightUp,Color.blue);
        Debug.DrawLine(player1LeftDown,player1RightDown,Color.blue);
        
        player1Bounds.Add(player1LeftUp);
        player1Bounds.Add(player1LeftDown);
        player1Bounds.Add(player1RightUp);
        player1Bounds.Add(player1RightDown);
        player1Bounds.Add(player1LeftUp);
        player1Bounds.Add(player1RightUp);
        player1Bounds.Add(player1LeftDown);
        player1Bounds.Add(player1RightDown);
    }

    public void BulletDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    
}
