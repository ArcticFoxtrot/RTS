using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	Dictionary<Vector2Int, Waypoint> cubeGrid = new Dictionary<Vector2Int, Waypoint>();

	[SerializeField] Waypoint startPoint;
	[SerializeField] Waypoint endPoint;

	// Use this for initialization
	void Start () {
		LoadCubes();
		ColorStartAndEndPoints();

		}

	private void ColorStartAndEndPoints() {
		//after all waypoints have been listed, separate starting and ending for pathfinder
		startPoint.SetTopColor(Color.green);
		endPoint.SetTopColor(Color.red);
		}

	private void LoadCubes() {
		Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints) {
			//see overlap in waypoints
			//add to dictionary
			bool isOverlapping = cubeGrid.ContainsKey(waypoint.GetGridPos());
			if (isOverlapping == false) {
				cubeGrid.Add(waypoint.GetGridPos(), waypoint);
				if (waypoint != startPoint || waypoint != endPoint) {
					waypoint.SetTopColor(Color.clear);
					}
				} else if (isOverlapping) {
				Debug.LogWarning(waypoint.name + " is overlapping with another waypoint");
				}
			}
		print(cubeGrid.Count + " waypoints loaded");
		}

	// Update is called once per frame
	void Update () {
		
	}
}
