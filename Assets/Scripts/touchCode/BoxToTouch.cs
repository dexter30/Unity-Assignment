using UnityEngine;
using System.Collections;


//This code is used to just check if the player is touching a box with colliders.
public class BoxToTouch : MonoBehaviour {
	GameRukes rules;
	// Use this for initialization
	void Start () {
		rules = GameRukes.instance;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Input.touchcount just incrments everytime a player touches the screen therefore we can
		//tell what the player is doing I use it to get the touch position and cross reference it
		//with the box colliders bounds and return a value to see whether or not it's touched.

		if (Input.touchCount > 0)
		{


			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);

			//Then we tell the singleton about this to continue with its functions.	
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				rules.setTouch(true);
				
			}


		}

		if (Input.touchCount == 0) 
		{
			rules.setTouch(false);
		}
	
	}
}
