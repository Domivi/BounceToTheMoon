using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.canMove = false;
            Debug.Log("Game over, wack wack");
        }
    }
}
