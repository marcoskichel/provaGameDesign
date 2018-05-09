using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardBehavior : MonoBehaviour {

	Rigidbody2D body;
	float timer;
	float movingTimeHandcap;
	float movingTime;

	double boardDimension = (float) 2.25 / 8;

	public Text scoreText;
	public Text timerText;

	int score = 0;
	float levelMod = 0;

	bool colliding;
	ContactPoint2D contact;

	// Use this for initialization
	void Start () {
		levelMod = 0;
		body = GetComponent<Rigidbody2D> ();
		colliding = false;
		timer = 30;
		movingTime = 0;
		movingTimeHandcap = 4;
		randomlyUpdateMovingDirection ();
		scoreText.text = "Score: 0";
		timerText.text = timer + "";
	}
	
	// Update is called once per frame
	void Update () {
		detectHit ();
		updateTimer ();
		changeDirectionsIfNeeded ();
	}

	void detectHit() {
		if (colliding && Input.GetKeyDown(KeyCode.Space)) {
			double colY = (boardDimension + (body.position.y * -1)) / (contact.point.y + (body.position.y * -1));
			double colX = (boardDimension + (body.position.x * -1)) / (contact.point.x + (body.position.x * -1));
			int absY = Mathf.RoundToInt (Mathf.Abs((float)colY));
			int absX = Mathf.RoundToInt (Mathf.Abs((float)colX));
			if (absY % 2 == 1 && absX % 2 == 1) {
				score += 5;
			} else {
				score -= 5;
			}
			scoreText.text = "Score: " + score;
			if (score < 0) {
				restart ();
			}
		}	
	}

	void restart() {
		SceneManager.LoadScene (0);
	}

	void OnCollisionEnter2D(Collision2D col) {
		colliding = true;
		contact = col.contacts[0];
	}

	void OnCollisionExit2D(Collision2D col) {
		colliding = false;
	}

	private void updateTimer() {
		timer -= Time.deltaTime;
		timerText.text = timer + "";
		if (timer < 0) {
			nextLevel();
		}
	}

	private void nextLevel() {
		levelMod += 0.1f;
		timer = 30;
		timerText.text = timer + "";
	}

	private void changeDirectionsIfNeeded() {
		movingTime += Time.deltaTime;

		if (body.position.y > 5) {
			body.velocity = new Vector2 (Random.Range (-5 - levelMod, 5 + levelMod), Random.Range (-1 - levelMod, -5 - levelMod));
		} else if (body.position.y < -5) {
			body.velocity = new Vector2 (Random.Range (-5 - levelMod, 5 + levelMod), Random.Range (1 + levelMod, 5 + levelMod));
		}

		if (body.position.x > 5) {
			body.velocity = new Vector2 (Random.Range (-1 - levelMod, -5 - levelMod), Random.Range (-5 - levelMod, -5 - levelMod));
		} else if (body.position.x < -5) {
			body.velocity = new Vector2 (Random.Range (1 + levelMod, 5 + levelMod), Random.Range (-5 - levelMod, -5 - levelMod));
		}

		if (movingTime >= movingTimeHandcap) {
			randomlyUpdateMovingDirection();
			movingTime = 0;
		}
	}

	private void randomlyUpdateMovingDirection() {
		body.velocity = new Vector2 (Random.Range (-5 - levelMod, 5 + levelMod), Random.Range (-5 - levelMod, 5 + levelMod));
	}
}
