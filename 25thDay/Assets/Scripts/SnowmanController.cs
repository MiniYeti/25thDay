using UnityEngine;
using System.Collections;

public class SnowmanController : MonoBehaviour {
	public Transform leftPoint;
	public Transform rightPoint;

	public float moveSpeed;

	private Rigidbody2D myRigidBody;

	public bool movingRight;

	private Animator snowmanAnim;

    public GameObject deathEffect;



	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		snowmanAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		
		if (movingRight && transform.position.x > rightPoint.position.x) 
		{
			movingRight = false;
		}

		if (!movingRight && transform.position.x < leftPoint.position.x) 
		{
			movingRight = true;
		}

		if (movingRight) {
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (-1f, 1f, 1f);

		} 
		else 
		{
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "StompBox") 
		{
			
			GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;


			foreach (BoxCollider2D  c in GetComponents<BoxCollider2D>()) 
			{
				c.enabled = false;	
			}


            Instantiate(deathEffect, gameObject.transform.position, gameObject.transform.rotation);

			snowmanAnim.Play("SnowmanDeath");

			StartCoroutine (DeathDelay ());


		
		}
			
	}

	IEnumerator DeathDelay()
	{
		yield return new WaitForSeconds (3);
		gameObject.SetActive (false);
	}

	void OnEnable()
	{
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
		foreach (BoxCollider2D  c in GetComponents<BoxCollider2D>())
		{
			c.enabled = true;	
		}
	}
}
