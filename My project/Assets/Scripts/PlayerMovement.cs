using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController player;
    public float moveSpeed = 10f;
    float jumpHeight = 1f;

    //Gravity
    public float g = -9.81f;

    Vector3 v;

    public Transform groundedCheck;
    float groundDist = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundedCheck.position, groundDist, groundMask);

        if (isGrounded && v.y < 0)
        {
            //Small number just to assure player is grounded
            v.y = -1f;
        }

        v.y += g * Time.deltaTime;

        player.Move(v * Time.deltaTime);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Construct movement direction vector based on player's referencial,
        //so the player moves according to where he's looking
        Vector3 MoveDirection = transform.right * x + transform.forward * z;

        player.Move(MoveDirection * moveSpeed * Time.deltaTime);

        bool isJumping = Input.GetButton("Jump");

        if (isGrounded && isJumping) 
        {
            v.y = Mathf.Sqrt(jumpHeight * -2f * g);
        }
    }
}
