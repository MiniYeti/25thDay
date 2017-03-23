using UnityEngine;
using System.Collections;

public class DestroyAfterDelay : MonoBehaviour {

	//private LevelManager theLevelManager;

	// Use this for initialization
	void Start () {
		//theLevelManager = FindObjectOfType<LevelManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			StartCoroutine (Delay ());
			Debug.Log ("OH YEAH!");
		}
	
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds (2);
		gameObject.SetActive (false);
	}
}
