using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	private List<Waypoint> path;

	// Use this for initialization
	void Start () {
		Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
		path = pathFinder.GetPath();
		StartCoroutine(FollowPath(path));
		}

	IEnumerator FollowPath(List <Waypoint> path) {
		print("Patrol starts");
		foreach (Waypoint waypoint in path) {
			print("Visiting waypoint: " + waypoint.name);
			// repeat after time
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(2f);
			}
		print("Patrol ends");
		}

	// Update is called once per frame
	void Update () {
		
	}
}
