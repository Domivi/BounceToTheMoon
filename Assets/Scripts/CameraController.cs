using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float zOffSet = 10f;
    [SerializeField] private float yOffSet = 5f;
    // [SerializeField] private float smoothStepSeconds = 0.2f;
    private float xPosition = 0f;
    private Vector3 finalCameraPosition;
  
    void LateUpdate()
    {
        finalCameraPosition = new Vector3(xPosition, player.maxHeight - yOffSet, player.gameObject.transform.position.z - zOffSet);
        transform.position = finalCameraPosition;
        // Maybe make it so that whenever player's rb.velocity.y is positive, the camera should be higher on y, and the opposite for negative.
    }
}
