using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		disallowMovingOutsideScreen ();
	}

	private void move() {
		if (Input.GetKey (KeyCode.RightArrow)) {
			body.velocity = new Vector2 (10, body.velocity.y);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			body.velocity = new Vector2 (-10, body.velocity.y);;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			body.velocity = new Vector2 (body.velocity.x, 10);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			body.velocity = new Vector2 (body.velocity.x, -10);
		} else {
			body.velocity = new Vector2(0, 0);
		}
	}

	private void disallowMovingOutsideScreen() {
		if (body.position.y > 5) {
			body.position = new Vector2(body.position.x, 5);
		} else if (body.position.y < -5) {
			body.position = new Vector2(body.position.x, -5);
		}

		if (body.position.x > 5) {
			body.position = new Vector2(5, body.position.y);
		} else if (body.position.x < -5) {
			body.position = new Vector2(-5, body.position.y);
		}
	}
}
