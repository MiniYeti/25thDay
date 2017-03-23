using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public Rigidbody2D myRigidBody;

	public float jumpSpeed;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool IsGrounded;



	private Animator myAnim;

	public Vector3 respawnPosition;

	public LevelManager theLevelManager;



	public GameObject stompBox;

	public float knockbackForce;
	public float knockbackLength;
	private float knockbackCounter;

	public float invincibiltyLength;
	private float invincibiltyCounter;

    public AudioSource jumpSound;
    public AudioSource hurtSound;

    public bool canMove;

    private CameraController theCamera;
    public float shakeAmount;



    // Use this for initialization
    void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		respawnPosition = transform.position;

		theLevelManager = FindObjectOfType<LevelManager> ();

        canMove = true;

        theCamera = FindObjectOfType<CameraController>();

	
	}
	
	// Update is called once per frame
	void Update () {



		IsGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (knockbackCounter <= 0 && canMove) 
		{

			if (Input.GetAxisRaw ("Horizontal") > 0f) {
				myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
				myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			} 
			else 
			{
				myRigidBody.velocity = new Vector3 (0f, myRigidBody.velocity.y, 0f);
			}

			if (Input.GetButtonDown ("Jump") && IsGrounded) 

			{
				myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
                jumpSound.Play();
			} 


		}	

		if (knockbackCounter > 0) 
		{
			knockbackCounter -= Time.deltaTime;

			if (transform.localScale.x > 0) {
				myRigidBody.velocity = new Vector3 (-knockbackForce, knockbackForce, 0f);
			
			} else {
				myRigidBody.velocity = new Vector3 (knockbackForce, knockbackForce, 0f);
			}
		}
		if (invincibiltyCounter > 0) 
		{
			invincibiltyCounter -= Time.deltaTime;
		}

		if (invincibiltyCounter <= 0) 
		{
			theLevelManager.invincible = false;
		}

		myAnim.SetFloat ("Speed", Mathf.Abs (myRigidBody.velocity.x));
		myAnim.SetBool ("Grounded", IsGrounded);


		if (myRigidBody.velocity.y < 0) {
			stompBox.SetActive (true);
            
        } else {
			stompBox.SetActive (false);
		}
			
	}

	public void Knockback()
	{
		knockbackCounter = knockbackLength;
		invincibiltyLength -= invincibiltyLength; 
		theLevelManager.invincible = true;
        theCamera.ScreenShake(shakeAmount);
    }

	void OnTriggerEnter2D(Collider2D other){		
		if (other.tag == "KillPlane") 
		{
            theLevelManager.healthCount = 0;
			theLevelManager.UpdateHeartMeter ();
            theCamera.ScreenShake(shakeAmount);



        }

		if (other.tag == "CheckPoint") 
		{
			respawnPosition = other.transform.position;

		}
	}



}
