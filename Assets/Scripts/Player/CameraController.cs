using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform cam;
    [SerializeField] private float cameraDistance = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private LayerMask collisionLayer;
    private Vector2 MouseInput;
    private float currentRotationY = 0f;
    [SerializeField] private float minYVectorAngle = -45f;
    [SerializeField] private float maxYVectorAngle = 45f;
    private void LateUpdate()
    {
        MouseInput.x = Input.GetAxis("Mouse X")*mouseSensitivity;
        MouseInput.y = Input.GetAxis("Mouse Y")*mouseSensitivity;
        currentRotationY -= MouseInput.y;
        currentRotationY = math.clamp(currentRotationY, minYVectorAngle,maxYVectorAngle);
        playerBody.Rotate(Vector3.up * MouseInput.x);
        cam.localRotation = Quaternion.Euler(currentRotationY,0,0);
        Vector3 desiredPosition = playerHead.position + cam.forward * -cameraDistance;
        Vector3 finalPosition = CheckCameraCollision(desiredPosition);

        cam.position = finalPosition;
    }

    public Vector3 CheckCameraCollision(Vector3 desirePosition)
    {
        if(Physics.Linecast(playerHead.position,desirePosition,out RaycastHit hit,collisionLayer))
        {
            return hit.point + cam.forward * 0.1f;
        } 
        return desirePosition;
        
    }
}
