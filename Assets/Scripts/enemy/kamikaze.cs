using UnityEngine;
using System.Collections;

//This is the code for the kamikaze ship that will ram into the player.
public class kamikaze : MonoBehaviour {

	//target gets player position.
	private Vector3 target;
	GameRukes rules;
	private float speed = 4.0f; 

	// Use this for initialization
	void Start () {
		//get singleton
		rules = GameRukes.instance;
		//get target position at instantiation.
		target = rules.getPlayer () -transform.position;
		target.Normalize ();


	}
	
	// Update is called once per frame
	void Update () {
		//move until we hit player
		transform.position += target * Time.deltaTime * speed;
		//damage is applied in the players script.
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
