using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
			}
	
	// Update is called once per frame


	IEnumerator SpawnEnemy() {
		while (true) {
			Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
			// spawn
			//print("Spawning!");
			yield return new WaitForSeconds(secondsBetweenSpawns);
			}
		}
}
