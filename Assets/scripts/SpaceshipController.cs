using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour {

	public GameObject bullet;

	private Rigidbody2D body;
	public Text scoreText;

	public static int score = 0;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("right")) {
			body.velocity = new Vector2(10, body.velocity.y);
		} else if (Input.GetKey ("left")) {
			body.velocity = new Vector2(-10, body.velocity.y);;
		} else {
			body.velocity = new Vector2(0, body.velocity.y);
		}

		if (Input.GetKeyDown("space")) {
			Instantiate (bullet, transform.position, Quaternion.identity);
		}
		scoreText.text = score + "";
	}
}
