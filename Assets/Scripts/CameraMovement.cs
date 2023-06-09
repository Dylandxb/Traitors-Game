using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;                                                     //Assign "Player" as target to be followed
    public float smoothing;                                                     //Smoothness of camera follow
    public Vector2 maxCameraBoundary;                                           //Using move tool to find the boundaries of the maze map
    public Vector2 minCameraBoundary; 

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(transform.position != target.position)                                                               
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);       
            targetPosition.x = Mathf.Clamp(targetPosition.x, minCameraBoundary.x, maxCameraBoundary.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minCameraBoundary.y, maxCameraBoundary.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
