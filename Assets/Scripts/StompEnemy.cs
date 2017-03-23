using UnityEngine;
using System.Collections;

public class StompEnemy : MonoBehaviour {



	private Rigidbody2D playerRigidBody;

	public float bounceForce;
    public LevelManager theLevelManager;

    // Use this for initialization
    void Start () {
		playerRigidBody = transform.parent.GetComponent<Rigidbody2D> ();
        theLevelManager = FindObjectOfType<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
			{

			playerRigidBody.velocity = new Vector3 (playerRigidBody.velocity.x, bounceForce, 0f);
            theLevelManager.hurtSound.Play();

        }
	}
}



