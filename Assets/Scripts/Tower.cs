using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;

	private Vector3 worldUp;

	// Use this for initialization
	void Start () {
		worldUp = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		objectToPan.LookAt(targetEnemy, worldUp);
	}
}
