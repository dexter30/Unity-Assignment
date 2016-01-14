using UnityEngine;
using System.Collections;

//This is parralax code for the background
//This just loops while the game is running. 
public class parralax : MonoBehaviour {
	//tilesize is the size of the object which is useful so we know how far back to move the image for a seamless effect.
    private float scrollSpeed = 2f;
	private float tileSizeZ = 17.15f;


	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		//mathf repeat will repeat the image after it reaches the limit (tilesizez);
		float NewPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);

		transform.position = new Vector2 (startPosition.x + Vector3.left.x * NewPosition, transform.position.y);
		
            
	}

   
}
