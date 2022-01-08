using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [SerializeField] private Camera mainCamera; 
    private Vector3 playerLocation;
    private bool canMove = true;
    public Rigidbody2D rb;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
        if (!canMove) return;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        playerLocation = new Vector3(mouseWorldPosition.x, transform.position.y, 0f);
        transform.position = playerLocation;
    }
}
