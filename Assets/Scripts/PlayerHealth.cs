using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] float playerHealth = 10f;
	[SerializeField] float healthDecrease = 1f;


	private void OnTriggerEnter(Collider other) {
		playerHealth = playerHealth - healthDecrease;
		print("the player's health now is: " + playerHealth);
		}

	}
