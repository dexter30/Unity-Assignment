using UnityEngine;
using System.Collections;

public class mineShooters : MonoBehaviour {

	//we have some delay code in this script so the ai doesn't spam.
	private Vector3 target;
	GameRukes rules;
	private float speed = 2.0f; 
	public GameObject m_bullet;
	private float lastBullet = 0f;
	private float shootDelay = 1f;
	private float health = 1.0f;
	public GameObject explosion;
	private int Score = 1000;


	// Use this for initialization
	void Start () {
		rules = GameRukes.instance;
		
		target = rules.getPlayer () -transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		//This enemy just flies upwards and shoots bullets in a timely fashion.
		transform.position = new Vector2 (transform.position.x, transform.position.y + speed * Time.deltaTime);

		if (Time.fixedTime - lastBullet < shootDelay) {
		} else {
			
			lastBullet = Time.fixedTime;
			Instantiate (m_bullet, transform.position, transform.rotation);
			
		}

	
		if (health <= 0) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			rules.changeScore(1000);
			Destroy (gameObject);
		}
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	//Collision here is similar to the other enemy. react accordingly to the specific object.
	void OnCollisionEnter2D(Collision2D _coll)
	{
		
		switch (_coll.gameObject.tag) {
		case "enemyBullet":
			health = health - Score;
			Destroy (_coll.gameObject);
			break;
		case "goodShip":
			
			break;
		case "Bomb":
			health = health - 1;
			Destroy(gameObject);
			Instantiate (explosion, transform.position, Quaternion.identity);

			break;
		default:
			break;
		}
	}
}
