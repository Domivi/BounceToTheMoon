using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] private Player player;

    public delegate void OnGameOver();
    public static event OnGameOver onGameOver;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.canMove = false;
            onGameOver();
        }
    }
}
