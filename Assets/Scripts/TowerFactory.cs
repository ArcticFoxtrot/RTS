using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit;
	[SerializeField] Tower towerPrefab;
	[SerializeField] Transform towerParent;

	Queue<Tower> towerQueue = new Queue<Tower>();


	

	// Use this for initialization

	public void AddTower(Waypoint baseWaypoint) {
		print(towerQueue.Count);
		if (towerQueue.Count < towerLimit) {
			SpawnTower(baseWaypoint);
			} else {
			MoveTower(baseWaypoint);
			}
		}

	private void MoveTower(Waypoint newBaseWaypoint) {
		var  oldTower = towerQueue.Dequeue();
	
		oldTower.baseWaypoint.isPlaceable = true;
		newBaseWaypoint.isPlaceable = false;
		
		oldTower.baseWaypoint = newBaseWaypoint;
		oldTower.transform.position = newBaseWaypoint.transform.position;
		towerQueue.Enqueue(oldTower);
		}

	private void SpawnTower(Waypoint baseWaypoint) {
		var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		newTower.transform.parent = towerParent;
		baseWaypoint.isPlaceable = false;
		newTower.baseWaypoint = baseWaypoint;
		baseWaypoint.isPlaceable = false;
		towerQueue.Enqueue(newTower);

		}
	}
