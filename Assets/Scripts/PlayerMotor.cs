using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //recieve the inputs for our InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 input)
    {
        /* Vector3 moveDirection = Vector3.zero;
         moveDirection.x = input.x;
         moveDirection.y = input.y;
         controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
         playerVelocity.y += gravity * Time.deltaTime;
         controller.Move(playerVelocity * Time.deltaTime);
         Debug.Log(playerVelocity.y);*/

      
        
        
        
        
        
        isGrounded = controller.isGrounded;

        // Create the movement direction as a 3D vector
        Vector3 moveDirection = Vector3.zero;

        // Use input.x for left/right movement and input.y for forward/backward movement
        moveDirection.x = input.x; // A/D or Left/Right
        moveDirection.z = input.y; // W/S or Up/Down

        // Transform the movement direction based on the player's rotation
        moveDirection = transform.TransformDirection(moveDirection);

        // Apply movement
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Handle gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Small value to keep the player grounded
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime; // Apply gravity
        }

        // Apply vertical movement (gravity)
        controller.Move(playerVelocity * Time.deltaTime);

        // Debug the Y velocity (optional, can be removed)
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
