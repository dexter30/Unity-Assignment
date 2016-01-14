using UnityEngine;
using System.Collections;

//Enemystat will basically handle information pertaining to the enemy. health, ammo, score.
//unfortunately I had to make seperate scripts for the other enemies instead of inheriting from this script.
public class enemyStat : MonoBehaviour {

	private int health = 1;
	//We keep a reference of the explosion so we can use it freely in code.
	public GameObject explosion;
	private int Score = 1000;
	private GameRukes rules;
	// Use this for initialization

	void Start () {
		//Keep a reference of the game rules class because it's a singleton.
		rules = GameRukes.instance;
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Collision code. if it reacts to an object with a specific tag
	//We react accordingly.
	void OnCollisionEnter2D(Collision2D _coll)
	{

		switch (_coll.gameObject.tag) 
		{
		case "enemyBullet":
			health = health - Score;
			Destroy (_coll.gameObject);
			break;
		case "goodShip":

			break;
		case "Bomb":
			health = health - 1;
			break;
		case "box":
			Destroy(gameObject);
			break;

		default:
			break;
		}
	
		//If the AI's code drops below a specific number it just kills itself an spawn a particle system explosion.
		if (health <= 0) {
			Instantiate (explosion, transform.position, Quaternion.identity);
			rules.changeScore(1000);
			Destroy (gameObject);
		}
	}


}
