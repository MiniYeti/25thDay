using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileControlButtons : MonoBehaviour
{

    public PlayerController thePlayer;

    // Use this for initialization
    void Start() {
        thePlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update() {
        //thePlayer.IsGrounded = Physics2D.OverlapCircle(thePlayer.groundCheck.position, thePlayer.groundCheckRadius, thePlayer.whatIsGround);

    }

   

    public void StartRight()
    {
        
         thePlayer.myRigidBody.velocity = new Vector3(thePlayer.moveSpeed, thePlayer.myRigidBody.velocity.y, 0f);
        thePlayer.transform.localScale = new Vector3(1f, 1f, 1f);
    }


    public void StopRight()
    {

        thePlayer.myRigidBody.velocity = new Vector3(0f, 0f, 0f);
        thePlayer.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void StartLeft()

    {
        
        thePlayer.myRigidBody.velocity = new Vector3(-thePlayer.moveSpeed, thePlayer.myRigidBody.velocity.y, 0f);
        thePlayer.transform.localScale = new Vector3(-1f, 1f, 1f);
       
    }

    public void StopLeft()

    {

        thePlayer.myRigidBody.velocity = new Vector3(0f, 0f, 0f);
        thePlayer.transform.localScale = new Vector3(-1f, 1f, 1f);

    }
    public void Jump()
        
    {
        if (thePlayer.IsGrounded)
        {
            thePlayer.myRigidBody.velocity = new Vector3(thePlayer.myRigidBody.velocity.x, thePlayer.jumpSpeed, 0f);
            thePlayer.jumpSound.Play();
        }
        
    }

}


