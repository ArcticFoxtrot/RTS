using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] float movementPeriod = .5f;
	[SerializeField] ParticleSystem goalParticleSystem;

	private List<Waypoint> path;
	private EnemyDamage thisEnemy;


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
			yield return new WaitForSeconds(movementPeriod);
			}
		print("Patrol ends");
		thisEnemy = GetComponentInParent<EnemyDamage>();
		SelfDestruct();

		}

	private void SelfDestruct() {
		ParticleSystem goalFX = Instantiate(goalParticleSystem, transform.position, Quaternion.identity);
		goalFX.Play();
		float destroyVFXDelay = goalFX.main.duration;
		Destroy(goalFX.gameObject, destroyVFXDelay);
		Destroy(gameObject);
		}

	// Update is called once per frame
	void Update () {
		
	}
}
