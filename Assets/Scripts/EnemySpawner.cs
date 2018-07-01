using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
			}
	
	// Update is called once per frame


	IEnumerator SpawnEnemy() {
		while (true) {

			// spawn
			print("Spawning!");
			yield return new WaitForSeconds(secondsBetweenSpawns);
			}
		}
}
