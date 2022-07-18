using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMov : MonoBehaviour
{
    float speed;
    bool pressSpace;
    bool pressEnter;

    private DiceRoll diceRoll;


    // Update is called once per frame
    void Update()
    {

        pressSpace = Input.GetKeyDown(KeyCode.Space);
        pressEnter = Input.GetKeyDown(KeyCode.Return);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8;
        }
        else
        {
            speed = 6;
        }

    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(z, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        //animator.SetBool("isWalking", isWalking);
    }
}
