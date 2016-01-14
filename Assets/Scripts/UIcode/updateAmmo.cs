using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//This is the ammo code similar to the other UI code is just updates the canvas information

public class updateAmmo : MonoBehaviour {

	private Text score ;
	private GameRukes rules;
	// Use this for initialization
	void Start () {
	
		score = GetComponent<Text>();
		rules = GameRukes.instance;
		//We have to send a reference to this instance to the sinleton so it knows where to sen information.
		rules.getAmmoBar (this);
		score.text = rules.getAmmo().ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateScore()
	{
		score.text = rules.getAmmo().ToString();
	//We simple update the text in the canvas object.
	}
}
