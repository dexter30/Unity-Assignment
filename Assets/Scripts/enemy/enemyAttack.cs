using UnityEngine;
using System.Collections;

//The purpose of the enemy ship will be to fly in the way of the players movement and then start firing rapidly. 
//The code will then need to fly to a position in front of thr player then it will hover until death or victory.

public class enemyAttack : MonoBehaviour {
	public GameObject m_bullet;
	private float lastBullet = 0f;
	private float shootDelay = 1f;
	private float speed = 4.0f; 
	private GameRukes rules;
	private Vector3 target;

	//errspace is the variable I represent the area  in which i want to plane to stop moving to shoot the user in the y axis
	private float errSpace = 0.5f;


	void Start () {
	
		rules = GameRukes.instance;
		//This gets us the direction towards the player. 
		target = rules.getPlayer () -transform.position;
		//Then I add a random position along the x axis so I can give the enemy a sort of unexpected factor.
		target.x = Random.Range (-8, 0);
		target.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		//
	//This will keep the ship moving until it reaches the same y space as the players ship. 
		if (!(transform.position.y >= target.y - errSpace&& transform.position.y <= target.y + errSpace)) 
		{
			transform.position += target * Time.deltaTime * speed;
		}
	
		//This will handle the ship if it gets too close.
		if (transform.position.x == target.x) 
		{
			if (transform.position.y >target.y)
			{
			transform.position += Vector3.up * Time.deltaTime * speed;
			}
			else
			{
			transform.position -= Vector3.up * Time.deltaTime * speed;

			}

		}
	
		// This code shipis used to handle the shooting delay.
		if (Time.fixedTime - lastBullet < shootDelay) {
		} else {
			
			lastBullet = Time.fixedTime;
			Instantiate (m_bullet, transform.position  + Vector3.left, transform.rotation);
			
		}


	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

}
