using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 MoveDir;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float jumpHeight = 2f;
    private const float Gravity = -9.981f;
    [SerializeField] private float gravityMultiplty = 1f;
    private Vector3 velocity;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveByInput(Vector2 input)
    {
        MoveDir = transform.forward * input.y + transform.right * input.x;
        MoveDir *= moveSpeed;
        controller.Move(MoveDir * Time.deltaTime);
    }

    public bool IsGround()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);
    }

    public float GetGravity()
    {
        return Gravity * gravityMultiplty;
    }

    public void JumpByInput()
    {
        if(!IsGround())return;
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * GetGravity());
    }

    public void ImplementGravity()
    {
        if (IsGround() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += GetGravity() * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
