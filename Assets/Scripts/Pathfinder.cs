using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

	Dictionary<Vector2Int, Waypoint> cubeGrid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> waypointQueue = new Queue<Waypoint>();

	Vector2Int[] directions = {
		Vector2Int.up,
		new Vector2Int (1,1), // up right
		Vector2Int.right,
		new Vector2Int (1,-1), //down right
		Vector2Int.down,
		new Vector2Int (-1,-1), //down left
		Vector2Int.left,
		new Vector2Int(-1,1) //up left
	};

	[SerializeField] Waypoint startPoint;
	[SerializeField] Waypoint endPoint;

	private bool isSearching = true;

	// Use this for initialization
	void Start () {
		LoadCubes();
		ColorStartAndEndPoints();
		//ExploreNext();
		PathFind();
		}

	private void PathFind() {
		waypointQueue.Enqueue(startPoint);
		while (waypointQueue.Count > 0) {
			Waypoint searchPoint = waypointQueue.Dequeue();
			StopIfEndFound(searchPoint);
			if (!isSearching) {
				break;
				}
			}
		}

	private void StopIfEndFound(Waypoint searchPoint) {
		if (searchPoint == endPoint) {
			print("Searchpoint and endpoint are equal, stopping search");
			isSearching = false;
			}
		}

	private void ExploreNext() {
		foreach (Vector2Int direction in directions) {
			Vector2Int pathfinderCoordinates = startPoint.GetGridPos() + direction;
			try {
				cubeGrid[pathfinderCoordinates].SetTopColor(Color.cyan);
				} catch {
				// do nothing
				}
				}
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
