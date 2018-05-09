using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public int speed = -1;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector2 (0, speed);
		body.angularVelocity = Random.Range (-200, 200);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		string colliderName = collider.gameObject.name;
		if (colliderName == "bullet(Clone)") {
			SpaceshipController.score++;
			Destroy(gameObject);
		}
	}

}
