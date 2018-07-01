using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
		//start a coroutine
	}
	
	// Update is called once per frame


	IEnumerator SpawnEnemy() {
		// forever
			// spawn
			// wait
		}
}
