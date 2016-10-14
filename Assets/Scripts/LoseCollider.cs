using UnityEngine;
using System.Collections;
//for counting lives
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

	// trying to add game manager to count lives
	public static int lives = 3;
	public float resetDelay = 0f;
	public Sprite live2;
	public Sprite live1;
	public Sprite live3;

	public GameObject livesObj;
	//пыталась заставить жизни менять картинку
	//private Sprite[] livesSprites;

	private LevelManager levelManager;
	private Ball ball;

	void Start () {
		levelManager = GameObject.FindObjectOfType <LevelManager> ();
		ball = GameObject.FindObjectOfType <Ball>();
		// livesObj = GameObject.FindObjectOfType <Lives>();
		livesObj.GetComponent<SpriteRenderer>().sprite = live3;
	}

	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");
		lives--;
		//add condition for lives
		if (lives<1){ 
			livesObj.GetComponent<SpriteRenderer>().sprite = live3;
			lives = 3;
			levelManager.LoadLevel ("Lose");
		} else {
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset() {
		print ("Lives left " + lives);
		if (lives == 2) {
			livesObj.GetComponent<SpriteRenderer>().sprite = live2;
		} else if (lives == 1) {
			livesObj.GetComponent<SpriteRenderer>().sprite = live1;
		}
		ball.hasStarted = false;
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
	}



}
