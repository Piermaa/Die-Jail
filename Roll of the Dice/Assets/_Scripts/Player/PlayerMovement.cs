
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private DiceRoll diceRoll;
    private Rigidbody rb;

    Vector3 move;

    [SerializeField] float speed = 6;
    [SerializeField] float gravity = 4.5f;
    float fallVelocity;
    [SerializeField] float jumpForce = 2;

    bool pressSpace;
    bool pressShift;
    bool pressEnter;

    private void Start()
    {
        controller = FindObjectOfType<CharacterController>();
        rb = FindObjectOfType<Rigidbody>();
        diceRoll = FindObjectOfType<DiceRoll>();
    }

    void Update()
    {

        pressSpace = Input.GetKeyDown(KeyCode.Space);
        pressEnter = Input.GetKeyDown(KeyCode.Return);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 9f;
        }
        else
        {
            speed = 5;
        }

        SetGravity();
        PlayerSkills();
        pressShift = Input.GetKey(KeyCode.LeftShift);
        controller.Move(move * Time.deltaTime * speed);
    }
    private void FixedUpdate()
    {
        pressSpace = Input.GetKeyDown(KeyCode.Space);

    }
    public void PlayerSkills()
    {
        if (pressSpace && controller.isGrounded)
        {
         
            fallVelocity = jumpForce;
            move.y = fallVelocity;
            //diceRoll.RotateDice();
        }
    }
    public void SetGravity()
    {
        if (controller.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            move.y = fallVelocity;
            speed -= 0.5f;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            move.y = fallVelocity;
            speed += 0.5f;
        }
    }

}