using UnityEngine;
using System.Collections;

//This is the  script for the orb so the player has a visual image of how much health he has.

public class healthOrb : MonoBehaviour {

	private float health; 
	//7.78 is the scale size of the image. saving this is useful for calculations later.
	private float MaxHealth = 7.78f;
	private GameRukes rules;
	// Use this for initialization
	void Start () {
		//We relate this image to the singleton so we can send and give health informaion.
		//for the UI.
		rules = GameRukes.instance;
		rules.getHealthBar (this);
		UpdateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateHealth()
	{
		//This is the relate it to the maximum size of the 
		//Health orb sprite on the screen.
		health = (rules.getHealth ()*  MaxHealth/ 100); 

		transform.localScale = new Vector3(health, health, health);

	}
}
