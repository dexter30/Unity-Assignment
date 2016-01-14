using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this is similar to the ammo code we just update the information. for the UI then update the UI text/
public class UpdateScore : MonoBehaviour {

	//WE have a text variable for the canvas information.
	private Text score;
	private GameRukes rules;

	// Use this for initialization
	void Start () {
		//Get the gamerules singleton and the 
		//instance of the UI.
		score = GetComponent<Text>();
		rules = GameRukes.instance;
		rules.getScoreBar (this);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void updateScore()
	{
		//Then simply update the score.
		score.text = rules.getScore ().ToString();

	}
}
