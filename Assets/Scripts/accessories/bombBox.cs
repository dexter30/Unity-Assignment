using UnityEngine;
using System.Collections;


//This script allows us to spawn a bomb after clicking on a box. 
public class bombBox : MonoBehaviour
{
	//We initialise the rules and a collider for the box.
	private GameRukes rules;
	private Collider2D box;

	//generic delay information so we can spam bombs.
	private float lastBomb = 0f;
	private float shootDelay = 1f;

	// Use this for initialization
	void Start ()
	{
		//We get our singleton rules and the box its collider.
		rules = GameRukes.instance;
		box = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{


		// This is my touch code. I've made it react to multiple touches. 
		//If the user touches the bomb collider a bomb will be spawned from the gamerukes script.
		//I go through all the touches to make sure.
		if (Input.touchCount > 0) {
			int fingers = 0;
			foreach (Touch touch in Input.touches) {
				Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (fingers).position);
			
				Vector2 touchPos = new Vector2 (wp.x, wp.y);

				if (box == Physics2D.OverlapPoint (touchPos)) {

					rules.spawnBomb (rules.getPlayer (), new Quaternion (0f, 0f, 0.7f, -0.7f));

	
				}
				//We need to keep track of the touches on the screen fingers allow us to do this. 
				//by incrment we can check all the Input.GetTouch[] inputs.
				fingers++;
			}
		}

		//We then tell our singleton when a touch is made.
		//In retrospect this is actually quite useless.
		if (Input.touchCount == 0) {
			rules.setTouch (false);
		}
	
	}
}
