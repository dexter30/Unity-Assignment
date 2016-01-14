using UnityEngine;
using System.Collections;


//violence allows the enemies to shoot with a delay so the game doesn't become impossible.
public class violence : MonoBehaviour {
	public GameObject m_bullet;
	public GameObject m_bomb;
    private float lastBullet = 0f;
    private float shootDelay = 1f;


	private GameRukes rules;


	// Use this for initialization
	void Start () {
		rules = GameRukes.instance;

	}
	
	// Update is called once per frame
	void Update () {
		//shoot if the time has been long enough otherwise wait.
		if (rules.getTouch() == true) {
			// This code is used to handle the shooting delay.
			if (Time.fixedTime - lastBullet < shootDelay) {
			} else {

				lastBullet = Time.fixedTime;
				Instantiate (m_bullet, transform.position + Vector3.right, transform.rotation);
            
			}
		}



        
	 }


}
