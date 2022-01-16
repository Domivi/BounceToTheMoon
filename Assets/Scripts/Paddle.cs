using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private Vector2 force = new Vector2(0f, 1100f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player") && (col.gameObject.GetComponent<Player>().rb.velocity.y > 0)) return;
        col.gameObject.GetComponent<Player>().rb.AddForce(force);
    }
    
}


