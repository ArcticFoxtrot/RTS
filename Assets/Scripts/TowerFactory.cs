using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 3;
	[SerializeField] Tower towerPrefab;
	// Use this for initialization

	public void AddTower(Waypoint baseWaypoint) {
		if (FindObjectsOfType<Tower>().Length < towerLimit) {
			SpawnTower(baseWaypoint);
			} else {
			MoveTower();
			}
		}

	private static void MoveTower() {
		Debug.Log("Reached limit, cannot place tower");
		// todo: actually move
		}

	private void SpawnTower(Waypoint baseWaypoint) {
		Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		}
	}
