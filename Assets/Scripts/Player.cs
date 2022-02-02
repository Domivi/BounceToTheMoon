using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    [SerializeField] private Camera mainCamera; 
    [SerializeField] private float speed = 20f;
    private float xTeleportOffset = 0.05f;
    private Vector3 playerLocation;
    private bool debugCheck;
    public bool canMove = true;
    public Rigidbody2D rb;
    public float maxHeight = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) rb.gravityScale = 0.9f;

        //Setting maxHeight, used for the camera Y axis cap.
        if (maxHeight < transform.position.y)
            maxHeight = transform.position.y;

        // Movement
        if (!canMove) return;
        
        if (transform.position.x <= Coords.left.position.x)
        {
            playerLocation = new Vector3(Coords.right.position.x - xTeleportOffset, transform.position.y, transform.position.z);
            transform.position = playerLocation;
        }
        else if(transform.position.x >= Coords.right.position.x)
        { 
            playerLocation = new Vector3(Coords.left.position.x + xTeleportOffset, transform.position.y, transform.position.z);
            transform.position = playerLocation;
        }
        else
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            playerLocation = new Vector3(mouseWorldPosition.x, transform.position.y, 0f);
            // transform.position = playerLocation;
            transform.position = new Vector3(Mathf.SmoothStep(transform.position.x, playerLocation.x, speed * Time.deltaTime),
                                             Mathf.SmoothStep(transform.position.y, playerLocation.y, speed * Time.deltaTime),
                                             Mathf.SmoothStep(transform.position.z, playerLocation.z, speed * Time.deltaTime));

        }

        
    }
}
