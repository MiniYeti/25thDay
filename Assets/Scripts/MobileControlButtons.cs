using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileControlButtons : MonoBehaviour
{

    public PlayerController thePlayer;
    public GameObject MobileButtonHolder;

    // Use this for initialization
    void Start() {
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITYWINRT
        MobileButtonHolder.SetActive(false);
  
        thePlayer = FindObjectOfType<PlayerController>();
#endif

    }

    // Update is called once per frame
    void Update() {
        

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


