using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {

	private LevelManager theLevelManager;

	public int presentValue;

    

	// Use this for initialization
	void Start () {
		theLevelManager = FindObjectOfType<LevelManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
       
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			theLevelManager.AddPresents (presentValue);
			

			gameObject.SetActive (false);
		}
	}
}
