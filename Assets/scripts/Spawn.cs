using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject enemy;
	public int spawnTime = 2;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnEnemy", 0, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnEnemy() {
		Renderer renderer = GetComponent<Renderer> ();
		var x1 = transform.position.x - renderer.bounds.size.x/2;
		var x2 = transform.position.x + renderer.bounds.size.x/2;
		Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);
		Instantiate(enemy, spawnPoint, Quaternion.identity);
	}
}
