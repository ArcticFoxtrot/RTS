using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] Transform enemyParent;

	private EnemyMovement enemy;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
			}
	
	// Update is called once per frame


	IEnumerator SpawnEnemy() {
		while (true) {
			enemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
			enemy.transform.parent = enemyParent;
			// spawn
			//print("Spawning!");
			yield return new WaitForSeconds(secondsBetweenSpawns);
			}
		}
}
