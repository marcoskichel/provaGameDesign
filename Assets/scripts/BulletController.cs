using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public int speed = 6;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (0, speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		string colliderName = collider.gameObject.name;
		if (colliderName == "enemy(Clone)") {
			Destroy(gameObject);
		}
	}
}
