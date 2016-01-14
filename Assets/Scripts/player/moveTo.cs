using UnityEngine;
using System.Collections;

//Player ship class, we just  tell the player ship where it needas to go in relation to our 
//touch input
public class moveTo : MonoBehaviour {
    //rigid body for physics reactions.
	Rigidbody2D ship;
    float speed = 5.0f;
    private float pos;
    private float screenY =  4.0f;
    public bool touchDown = false;
	private GameRukes rules;
	// Use this for initialization
	void Start () 
    {
		//Get game rules
        ship = GetComponent<Rigidbody2D>();
		rules = GameRukes.instance;
	}

	
	// Update is called once per frame
	void Update () 
    {
          //If the player is touching then perform the translation of the player ship.
         if (rules.getTouch() == true)
         {
			//input.gettouch(0) will get the players first finger and use it to 
			//change the position when he moves it. 
			//we use math clamp to limit the playes movement within screen space.
			pos = Mathf.Clamp(ship.transform.position.y + Input.GetTouch(0).deltaPosition.y * speed * Time.deltaTime, -screenY, screenY);

            //apply the translation.
            ship.MovePosition(new Vector2(ship.transform.position.x, pos));
			 
             
         }
	
        
         
           
	}

   
	//The collision works like the other classes we react accordingly./ enemies kill you
	//powerups call the singleton to affect gameplay ammunition.
	void OnCollisionEnter2D(Collision2D _coll)
	{
		switch (_coll.gameObject.tag) {
		case "goodBullet":
			rules.reduceHealth (5f);
			Destroy(_coll.gameObject);
			break;
		case "playerShip":
			rules.reduceHealth(10f);

			Destroy(_coll.gameObject);
			break;
		case "pill":
			rules.addBomb();
			Destroy(_coll.gameObject);
			break;
		case "health":
			rules.Medication();
			Destroy(_coll.gameObject);
			break;

		default:
			break;
		}
	}
}
