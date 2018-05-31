using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider enemyCollisionMesh;
	[SerializeField] int hitPoints = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnParticleCollision(GameObject other) {
		print("I'm hit!");
		ProcessHit();
		if (hitPoints <= 0) {
			KillEnemy();
			}
		}


	private void ProcessHit() {
		hitPoints = hitPoints - 1;

		}

	private void KillEnemy() {
		Destroy(gameObject);
		}

	}
