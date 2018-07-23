using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 2f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] Transform enemyParent;
	[SerializeField] Text scoreText;


	private int score = 0;
	private EnemyMovement enemy;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemy());
		scoreText.text = score.ToString();
		}
	
	// Update is called once per frame


	IEnumerator SpawnEnemy() {

		while (true) {
			AddScore();
			enemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
			enemy.transform.parent = enemyParent;
			yield return new WaitForSeconds(secondsBetweenSpawns);
			}
		}

	private void AddScore() {
		score++;
		scoreText.text = score.ToString();
		}
	}
