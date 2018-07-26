using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] float playerHealth = 10f;
	[SerializeField] float healthDecrease = 1f;
	[SerializeField] Text healthText;
	[SerializeField] AudioClip towerHitSFX;


	void Start() {
		healthText.text = playerHealth.ToString();
		}

	private void OnTriggerEnter(Collider other) {
		GetComponent<AudioSource>().PlayOneShot(towerHitSFX);
		playerHealth = playerHealth - healthDecrease;
		healthText.text = playerHealth.ToString();
		}

	}
