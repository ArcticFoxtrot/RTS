using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider enemyCollisionMesh;
	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem hitParticleSystem;
	[SerializeField] ParticleSystem deathParticleSystem;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnParticleCollision(GameObject other) {
		//print("I'm hit!");
		ProcessHit();
		if (hitPoints <= 0) {
			KillEnemy();
			}
		}


	private void ProcessHit() {
		hitPoints = hitPoints - 1;
		hitParticleSystem.Play();
		}

	private void KillEnemy() {
		ParticleSystem deathFX = Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
		deathFX.transform.parent = transform.parent;
		deathFX.Play();
		float destroyVFXDelay = deathFX.main.duration;
		Destroy(deathFX.gameObject, destroyVFXDelay);
		Destroy(gameObject);
		}

	}
