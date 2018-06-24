using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] float firingDistance = 10f;

	private Vector3 worldUp;
	private ParticleSystem weapon;

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

	private void Shoot(bool isActive) {
		var emissionModule = weapon.emission;
		emissionModule.enabled = isActive;
		}
	}
