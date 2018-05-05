using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	[SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start () {
		StartCoroutine(FollowPath());
		}

	IEnumerator FollowPath() {
		print("Patrol starts");
		foreach (Waypoint waypoint in path) {
			print("Visiting waypoint: " + waypoint.name);
			// repeat after time
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(1f);
			}
		print("Patrol ends");
		}

	// Update is called once per frame
	void Update () {
		
	}
}
