using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour {

	public Sprite sledgesClosed;
	public Animator sledgesOpen;

	public bool checkPointActive;

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Animator>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			
			gameObject.GetComponent<Animator>().enabled = true;
			checkPointActive = true;
		}
	}
}
