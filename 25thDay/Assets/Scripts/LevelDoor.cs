using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour {

    public string levelToLoad;
    public bool unlocked;

    public Sprite doorOpen;
    public Sprite doorClosed;

    public SpriteRenderer door;

    

    

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetInt("Level1", 1);
        if (PlayerPrefs.GetInt(levelToLoad) == 1)
        {
            unlocked = true;

        }
        else
        {
            unlocked = false;
        }

        if (unlocked)
        {
            door.sprite = doorOpen;
        }
        else {
            door.sprite = doorClosed;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Jump") && unlocked)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
            
    }

  
}
