using UnityEngine;
using System.Collections;

//This is our singleton in which we make the rules of the game.


public class GameRukes : MonoBehaviour {

//first we have an array of the prefabs in the script so we can call them, they are similar ship prefabs.
    public GameObject[] m_ship;
    public GameObject m_bullet;
    public GameObject m_pship;
	public GameObject m_bomb;
	public GameObject GameOver;
	private float health = 50f;
	private bool bombSpawned = false;
	private int bAmmo = 3; //bo
	private int multiplier = 1;
    public Transform playerSpawn;
	public Vector2 sHeight ;
	private int playerScore =0;
	private UpdateScore scoreBar;
	private updateAmmo ammoStats;
	private healthOrb healthBar;
	//public Vector2 sHeight = Camera.main.ViewportToWorldPoint(new Vector2(1f,1f))
	GameObject currentPlayer;




    public static GameRukes instance = null;
	private bool touchScreen = false;
    void Awake()
    {
		//we instantly initialise our singleton.
        if (instance != null)
        {
            Debug.LogError("singleton already in");
        }
        instance = this;
		//we have to reset our timescale because chances our we may have slowed it down at the end of the last game.
		//For the game over screen.
		Time.timeScale = 1.0f;

    }


	// Use this for initialization
	void Start () {
		//We simply get the screen size and imagery and 
		//spawn our player at the right location in relation to screen size. 
		//The following function basically gets the width and height dynamically in game.
		sHeight = Camera.main.ViewportToWorldPoint (new Vector2 (1f, 1f));
		currentPlayer = (GameObject)Instantiate(m_pship, new Vector2(-sHeight.x/1.5f , sHeight.y - sHeight.y) ,new Quaternion(0.7f,0.7f,0f,0f));

		//Then we start the spawning of the enemies, and health items.
		//invoke repeating will repeat the function repeatedly.
		InvokeRepeating ("SpawnGoodGuy", 1f, 3f);
		InvokeRepeating ("spawnKamikazes", 1f, 3f);
		InvokeRepeating ("SpawnShooters", 1f, 4f);
		InvokeRepeating ("spawnPills", 1f, 23f);
		InvokeRepeating ("medicBall", 1f, 23f);
	}

	//This is so other functions can get the players position.
	public Vector3 getPlayer()
	{
		return  currentPlayer.transform.position;
	}
	// Update is called once per frame
	void Update () {
	

		//We keep checking this until the player dies. 
		//So we can have a function call to get to the [post death screen.
		if (health <= 0)
		{

			if (Input.GetMouseButtonDown (0))
			{
				Application.LoadLevel("Menu");
				
			}
		}


	}

	//The following "spawn" functions basically spawn enemies for the initialisation. 
	//You can see in the start() function how they're used
	public GameObject spawnKamikazes()
	{
		return (GameObject)Instantiate(m_ship[1], new Vector3(8f, Random.Range(-sHeight.y,sHeight.y),0f), new Quaternion(0f,0f,0.7f, 0.7f));

	}
    public GameObject SpawnGoodGuy()
    {
		return (GameObject)Instantiate(m_ship[0], new Vector3(8f, Random.Range(-sHeight.y,sHeight.y),0f), new Quaternion(0f,0f,0.7f, 0.7f));
    }

	public GameObject SpawnShooters()
	{
		return (GameObject)Instantiate(m_ship[2], new Vector3(Random.Range(-sHeight.x+ 4f,sHeight.x),-5f,0f), new Quaternion(0f,0f,0.7f, 0.7f));

	}

	public GameObject spawnPills()
	{
		return (GameObject)Instantiate (m_ship [3], new Vector3 (8f, Random.Range (-sHeight.y, sHeight.y), 0f), new Quaternion (0f, 0f, 0.7f, 0.7f));
	}

	public GameObject medicBall()
	{
		return (GameObject)Instantiate (m_ship [4], new Vector3 (8f, Random.Range (-sHeight.y, sHeight.y), 0f), new Quaternion (0f, 0f, 0.7f, 0.7f));
	}

	//This is a useless function that allows you to let the whole game know
	//When exactly the player is touching.
	public void setTouch(bool _isScreenTouch)
	{
		touchScreen = _isScreenTouch;
	}

	//See set touch
	public bool getTouch()
	{
		return touchScreen;
	}

	//This is so we can spawn a bomb anywhere in any rotation
	//this is useful because the bomb ammo count is in the singleton. 
	public void spawnBomb(Vector3 _pos, Quaternion _rot)
	{

		if (bombSpawned == true || bAmmo == 0) {
			return;
		}
			Instantiate (m_bomb, _pos, _rot);
		bombSpawned = true;
	}

	//we can take from the bomb count here and update the UI 
	public void setBomb()
	{
		if (bAmmo == 0) {
			bombSpawned = true;
		} else {
			bombSpawned = false;

			bAmmo -= 1;
			Debug.Log(bAmmo);
			ammoStats.UpdateScore();
		}
		
	}

	//We also add bombs for when we hit a powerup.
	public void addBomb()
	{
		bAmmo += 1;
		ammoStats.UpdateScore();
	}

	//We add a score here when we kill an enemy. 
	//This is called form the enemy classes.
	public void changeScore(int _newScore)
	{
		playerScore = playerScore + _newScore * multiplier;
		multiplier = multiplier * 2;
		scoreBar.updateScore ();
	}

	//This is so the UI can call the ammo count and the player can know hoiw many bombs to spawn.
	public int getScore()
	{
		return playerScore;
	}
	

	//We need the instance of the score bar so we can update it.
	public void getScoreBar(UpdateScore _instance)
	{
		scoreBar = _instance;
	}
	//See get scorebar
	public void getAmmoBar( updateAmmo _instance)
	{
		ammoStats = _instance;
	}

	//see get health bar.
	public void getHealthBar( healthOrb _instance)
	{
		healthBar = _instance;
	}
	//So we can update the UI.
	public int getAmmo()
	{
		return bAmmo;
	}

	//Updating the UI>
	public float getHealth()
	{
		return health;
	}

	//reduce health for damage and updates UI.
public void reduceHealth(float _damage)
	{

		health -= _damage;
		healthBar.UpdateHealth ();
		if (health <= 0) 
		{
			Instantiate(GameOver);
			Time.timeScale =0.1f;
		}
	}

	//WE update the health and health powerup.
	public void Medication()
	{
		multiplier = 1;
		health += 40;
		healthBar.UpdateHealth ();
	}
    //singleton 
    
}
