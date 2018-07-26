using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider enemyCollisionMesh;
	[SerializeField] int hitPoints = 10;
	[SerializeField] ParticleSystem hitParticleSystem;
	[SerializeField] ParticleSystem deathParticleSystem;
	[SerializeField] AudioClip damageSFX;
	[SerializeField] AudioClip deathSFX;


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
		GetComponent<AudioSource>().PlayOneShot(damageSFX);
		}

	private void KillEnemy() {
		ParticleSystem deathFX = Instantiate(deathParticleSystem, transform.position, Quaternion.identity);
		deathFX.Play();
		float destroyVFXDelay = deathFX.main.duration;
		float destroySFXDelay = deathSFX.length;
		Destroy(deathFX.gameObject, destroyVFXDelay);
		AudioSource.PlayClipAtPoint(deathSFX, FindObjectOfType<AudioListener>().transform.position);
		//GetComponentInChildren<Collider>().enabled = false;
		//GetComponentInChildren<MeshRenderer>().enabled = false;
		//GetComponent<AudioSource>().PlayOneShot(deathSFX);
		Destroy(gameObject,destroySFXDelay);
		}

	}
