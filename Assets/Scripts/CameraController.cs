using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float zOffSet = 10f;
    [SerializeField] private float yOffSet = 5f;
    private float xPosition = 0f;
    private Vector3 finalCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalCameraPosition = new Vector3(xPosition, player.gameObject.transform.position.y - yOffSet, player.gameObject.transform.position.z - zOffSet);
        transform.position = finalCameraPosition;
        // Maybe make it so that whenever player's rb.velocity.y is positive, the camera should be higher on y, and the opposite for negative.
    }
}
