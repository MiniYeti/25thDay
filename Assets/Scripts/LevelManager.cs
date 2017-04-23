using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float waitToRespawn;
	public PlayerController thePlayer;

	public GameObject deathAnimation;

	public int presentCount;
    public int startingPresentCount;
    private int presentBonusLifeCount;
    public int bonusLifeTreshold;

    public Image heart1;
	public Image heart2;
	public Image heart3;

	public Sprite heartFull;
	public Sprite heartHalf;
	public Sprite heartEmpty;

	public int maxHealth;
	public int healthCount;

	private bool respawning;

	public ResetOnRespawn[] objectsToReset;

	public bool invincible;

	public int currentLives;
	public int startingLives;
	public Text livesText;

    public Text GiftsText;

    public GameObject gameOverScreen;
    public GameObject blackScreenHolder;
    public AudioSource presentSound;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource hurtSound;
    public AudioSource gameWinMusic;

    public bool isDead;

    public CameraController theCamera;


    





    // Use this for initialization
    void Start () {

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        theCamera = FindObjectOfType<CameraController>();

        blackScreenHolder.SetActive(true);

        thePlayer = FindObjectOfType<PlayerController> ();

		healthCount = maxHealth;

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();


        if (PlayerPrefs.HasKey("PresentCount"))
        {
            presentCount = PlayerPrefs.GetInt("PresentCount");
        }
        else {
            presentCount = startingPresentCount;
        }

        GiftsText.text = "GIFTS : " + presentCount;



        if (PlayerPrefs.HasKey("PlayerLives"))
        {        
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else {      
            currentLives = startingLives;
        }
        livesText.text = "LIVES x " + currentLives;


        



    }
	
	// Update is called once per frame
	void Update () {
		if (healthCount <= 0 && !respawning) 
		{
			
			Respawn ();
			respawning = true;

		}

        if (presentBonusLifeCount >= bonusLifeTreshold)
        {
            currentLives += 1;
            livesText.text = "LIVES x " + currentLives;
            presentBonusLifeCount -= bonusLifeTreshold;
            
        }

	}

	public void Respawn()
	{
		currentLives -= 1;
		livesText.text = "Lives x " + currentLives;   

		if (currentLives > 0) {
			StartCoroutine ("RespawnCo");
           
            isDead = false;
		} else {
            StartCoroutine("DeadCo");
            
            levelMusic.Stop();
            gameOverMusic.Play();

            isDead = true;
            

        }


	}

	public IEnumerator RespawnCo()
	{
		thePlayer.gameObject.SetActive (false);

        
       

        Instantiate (deathAnimation, thePlayer.transform.position, thePlayer.transform.rotation);

   

        yield return new WaitForSeconds (waitToRespawn);

		healthCount = maxHealth;
		respawning = false;
		UpdateHeartMeter ();

        presentCount = 0;
        presentBonusLifeCount = 0;
        GiftsText.text = "GIFTS :" + presentCount;

        thePlayer.transform.position = thePlayer.respawnPosition;
        theCamera.transform.position = theCamera.targetPosition;
        thePlayer.gameObject.SetActive (true);
        

        for (int i = 0; i < objectsToReset.Length; i++) 
		{
			objectsToReset [i].gameObject.SetActive (true);
			objectsToReset [i].ResetObject ();

		}
	}


    public IEnumerator DeadCo()
    {
        thePlayer.gameObject.SetActive(false);

        Instantiate(deathAnimation, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        thePlayer.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void AddPresents(int presentsToAdd)
	{
		presentCount += presentsToAdd;
        presentBonusLifeCount += presentsToAdd;
        GiftsText.text = "GIFTS :" + presentCount;

        presentSound.Play();
	}

	public void HurtPlayer(int damageToTake)
	{

		if (!invincible) 
		{
			healthCount -= damageToTake;
			UpdateHeartMeter ();

			thePlayer.Knockback ();
            thePlayer.hurtSound.Play();
        }
	}

    public void GiveHealth(int healthToGive)
    {
        healthCount += healthToGive;
        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }

        presentSound.Play();
        UpdateHeartMeter();
    }
	public void UpdateHeartMeter()
	{
		switch (healthCount) 
		{
		case 6:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			return;
		case 5:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartHalf;
			return;
		case 4:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartEmpty;
			return;
		case 3:
			heart1.sprite = heartFull;
			heart2.sprite = heartHalf;
			heart3.sprite = heartEmpty;
			return;
		case 2:
			heart1.sprite = heartFull;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;
		case 1:
			heart1.sprite = heartHalf;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		default:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;
			
		}

	}
}
