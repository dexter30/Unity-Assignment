using UnityEngine;
using System.Collections;

//This is the code for the help screen. It just displays 
//information then we just load the main menu after the user is done and touches down.
public class HelpScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Application.LoadLevel("Menu");
		}
	
	}


}
