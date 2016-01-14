using UnityEngine;
using System.Collections;

//This script tells the bomb what to do
//basically fly across the screen until collision then expand and kill.
public class BombScript : MonoBehaviour {

	private float speed = 1.0f;
	private bool boom = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

		//Boom is the sign that the bomb should start executing its main commands. 
		//Which are expand and kill self after expansion.
		if (boom == true) {
			transform.localScale += transform.localScale * Time.deltaTime;
			if (transform.localScale.x > 39) {
				GameRukes.instance.setBomb();
				Destroy (gameObject);
			}
		} 
		else 
		{
			//Otherwise keep flying until collision.
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}


	}

	//When we collide we kill other objects.
	void OnCollisionEnter2D(Collision2D _coll)
	{
		Debug.Log (_coll.gameObject.tag);
		if (_coll.gameObject.tag != "Player") {
			boom = true;
		}
	}

	//When we're offscreen kill ourselvs anyway.
	void OnBecameInvisible()
	{
		boom = true;

		Destroy(gameObject);

	}


}
