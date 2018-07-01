using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	// Parameters for towers
	[SerializeField] Transform objectToPan;
	[SerializeField] float firingDistance = 10f;

	// State of towers
	Transform targetEnemy;

	private Vector3 worldUp;
	private ParticleSystem weapon;
	private float distToClosest;
	private float distToTest;

	// Use this for initialization
	void Start () {
		worldUp = Vector3.up;
		weapon = gameObject.GetComponentInChildren<ParticleSystem>();
		if (!weapon) {
			Debug.Log("Tower weapon not found");
			} else { Debug.Log("Weapon system found"); }
	}
	
	// Update is called once per frame
	void Update () {
		SetTargetEnemy();
		if (targetEnemy) {
			objectToPan.LookAt(targetEnemy, worldUp);

			if (Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position) <= firingDistance) {
				Shoot(true);

				} else {
				Shoot(false);
				}
			} else {
			Shoot(false);
			}
	}

	private void SetTargetEnemy() {
		var sceneEnemies = FindObjectsOfType<EnemyDamage>();
		if (sceneEnemies.Length <= 0) {
			Debug.LogWarning("No enemies to target");
			return;
			}
		Transform closestEnemy = sceneEnemies[0].transform;
		foreach (EnemyDamage testEnemy in sceneEnemies) {
			closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
			}
		targetEnemy = closestEnemy;
		}

	private Transform GetClosest(Transform closestEnemy, Transform testEnemy) {
		//Vector3 distToClosest = this.transform.position - closestEnemy.transform.position;
		//Vector3 distToTest = this.transform.position - testEnemy.transform.position;
		//initial idea, going with vector3.distance
		distToClosest = Vector3.Distance(this.transform.position, closestEnemy.position);
		distToTest = Vector3.Distance(this.transform.position, testEnemy.position);
		if (distToClosest > distToTest ) {
			return testEnemy;
			} else {
			return closestEnemy;
			}
		}

	private void Shoot(bool isActive) {
		var emissionModule = weapon.emission;
		emissionModule.enabled = isActive;
		}
	}
