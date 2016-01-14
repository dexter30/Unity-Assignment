using UnityEngine;
using System.Collections;

//This is just code for our particle system explosion. I needed omsething to tell it to kill itself.
public class kilself : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	Destroy(gameObject,2.0f);

	
	}
}
