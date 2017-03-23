using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;
    public string levelToUnlock;

    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager theLevelManager;

    public float waitToMove;
    public float waitToLoad;

    private bool movePlayer;

   

    

    


   




    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();
        
        
       

    }
	
	// Update is called once per frame
	void Update () {

        

        if (movePlayer)
        {
            thePlayer.myRigidBody.velocity = new Vector3(thePlayer.moveSpeed, thePlayer.myRigidBody.velocity.y, 0f);
        }
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;
        theCamera.followTarget = false;
        theLevelManager.invincible = true;

        theLevelManager.levelMusic.Stop();
        theLevelManager.gameWinMusic.Play();

        thePlayer.myRigidBody.velocity = Vector3.zero;

        



        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("PresentCount", theLevelManager.presentCount);

        PlayerPrefs.SetInt(levelToUnlock, 1);




        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;

        
       
        

        yield return new WaitForSeconds(waitToLoad);
       

        SceneManager.LoadScene(levelToLoad);

    }

   
}
