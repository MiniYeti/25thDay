using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileControlButtons : MonoBehaviour
{

    public PlayerController thePlayer;
    public GameObject MobileButtonHolder;

    
    void Start()
    {
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITYWINRT
        //MobileButtonHolder.SetActive(false);
  
        thePlayer = FindObjectOfType<PlayerController>();
#endif
    }   
    void Update() {    
    }
    public void StartRight()

    {
        thePlayer.MoveRight();
    }

    public void StopRight()
    {
        thePlayer.myRigidBody.velocity = new Vector3(0f, thePlayer.myRigidBody.velocity.y, 0f);
    }
    public void StartLeft()
    {
       thePlayer.MoveLeft();
    }

    public void StopLeft()
    { 
      thePlayer.myRigidBody.velocity = new Vector3(0f, thePlayer.myRigidBody.velocity.y, 0f);     
    }
    public void Jump()      
    {
        thePlayer.Jump();
    }

}


