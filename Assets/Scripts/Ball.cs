using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool hasStarted = false;

	private Paddle paddle;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = new Vector3 (0.0f, 0.4f, 0.0f);
		// print (paddleToBallVector.y);

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {

			//trying to fix the problem with ball positioned in a wrong place after losing a life

			// Lock the ball relative to the paddle
			Vector2 initSpeed = new Vector2 (2f, 10f);
			this.transform.position = paddle.transform.position + paddleToBallVector;
			print ("paddle pos "+paddle.transform.position+ "paddle to ball (const) "+ paddleToBallVector+ "положение мяча на паддле "+this.transform.position);
			//Wait for a mouse press for a launch
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				// this.GetComponent<Rigidbody2D>().velocity = initSpeed + paddle.GetComponent<Rigidbody2D>().velocity;
				this.GetComponent<Rigidbody2D>().velocity = initSpeed;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			// print (paddle.GetComponent<Rigidbody2D>().velocity);
			GetComponent<AudioSource>().Play();
			if (collision.gameObject == paddle.gameObject) {
				float magnitude = GetComponent<Rigidbody2D>().velocity.magnitude;
				paddleToBallVector = this.transform.position - paddle.transform.position;
				GetComponent<Rigidbody2D>().velocity = paddleToBallVector.normalized*magnitude;
			} else {
			GetComponent<Rigidbody2D>().velocity +=tweak;
			}
		}
	}
}
