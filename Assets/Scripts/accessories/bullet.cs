using UnityEngine;
using System.Collections;
//Simple bullet behaviour script. fly until collision.
public class bullet : MonoBehaviour {
    private float speed = 5.0f;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       //Keep going "up" every frame.
        transform.Translate(Vector3.up * Time.deltaTime * speed);
	    
    }

	//kill self if we go offscreen.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


        
}
