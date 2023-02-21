using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float defaultMovementSpeed;
    public float extraAccelerationSpeed;
    public float breakingFactor;
    public float defaultTurnSpeed;

    bool left;
    bool right;

    private void FixedUpdate()
    {
        float movementSpeed = this.defaultMovementSpeed;//at start setting the default movement speed of the palyer

        //logic for moveing
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))//W or UpArrow key to apply booster on the player
        {
            movementSpeed += this.extraAccelerationSpeed;//setting the normal movement speed to booster speed when keys are pressed
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))//D or DownArrow key to apply slowing or Breaking on the player
        {
            movementSpeed *= this.breakingFactor;//setting the normal movement speed to breaking speed when keys are pressed
        }
        this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);//the normal speed the player will always have at the start of the game

        //logic for moveing left & Right
        //turning left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || left)//D or DownArrow key to apply slowing or Breaking on the player
        {
            this.transform.Rotate(Vector3.forward * defaultTurnSpeed * Time.deltaTime);//setting the normal movement speed to breaking speed when keys are pressed
        }
        //turning left
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || right)
        {
            this.transform.Rotate(-Vector3.forward * defaultTurnSpeed * Time.deltaTime); ;
        }
    }

    public void LeftButtonDown()
    {
        left = true;
    }
    public void LeftButtonUp()
    {
        left = false;
    }
    public void RightButtonDown()
    {
        right = true;
    }
    public void RightButtonUp()
    {
        right = false;
    }
}
