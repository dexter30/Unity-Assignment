using UnityEngine;
using System.Collections;


//This is just main menu code so we can load scenes when the players clicks on specific buttons. This script
//relates to the canvas in the menu scene.
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
		Application.LoadLevel ("ball");
	}

	public void helpScreen()
	{
		Application.LoadLevel ("help");
	}
}
