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


	private List<Waypoint> path = new List<Waypoint>();
	private bool isSearching = true;
	private Waypoint searchPoint;

	// Use this for initialization

	public List<Waypoint> GetPath() {
		LoadCubes();
		//ColorStartAndEndPoints();
		BreadthFirstSearch();
		CreatePath();
		return path;
		}

	private void CreatePath() {
		path.Add(endPoint);
		Waypoint breadCrumb = endPoint.foundFrom;
		while(breadCrumb != startPoint) {
			//add intermediate waypoints
			path.Add(breadCrumb);
			breadCrumb = breadCrumb.foundFrom;
			}
		path.Add(startPoint);
		path.Reverse();
		// add startpoint and reverse list
		}

	private void BreadthFirstSearch() {
		waypointQueue.Enqueue(startPoint);
		while (waypointQueue.Count > 0 && isSearching) {
			searchPoint = waypointQueue.Dequeue();
			searchPoint.isExplored = true;
			StopIfEndFound();
			ExploreNext();
			//explore next waypoints
			}
		}

	private void StopIfEndFound() {
		if (searchPoint == endPoint) {
			print("Searchpoint and endpoint are equal, stopping search");
			isSearching = false;
			}
		}

	private void ExploreNext() {
		if (!isSearching) { return; }
		foreach (Vector2Int direction in directions) {
			Vector2Int pathfinderCoordinates = searchPoint.GetGridPos() + direction;
			if(cubeGrid.ContainsKey(pathfinderCoordinates)) {
				QueueNextWaypoint(pathfinderCoordinates);
				} else {
				// do nothing
				}
				}
		}

	private void QueueNextWaypoint(Vector2Int pathfinderCoordinates) {
		Waypoint nextToExplore = cubeGrid[pathfinderCoordinates];
		if (nextToExplore.isExplored == false && !waypointQueue.Contains(nextToExplore)) {
			waypointQueue.Enqueue(nextToExplore);
			print("queueing " + nextToExplore.name);
			nextToExplore.foundFrom = searchPoint;
			}
		}

	//private void ColorStartAndEndPoints() {
	//	//after all waypoints have been listed, separate start and ending for pathfinder
	//	startPoint.SetTopColor(Color.green);
	//	endPoint.SetTopColor(Color.red);
	//	}

	private void LoadCubes() {
		Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints) {
			//see overlap in waypoints
			//add to dictionary
			bool isOverlapping = cubeGrid.ContainsKey(waypoint.GetGridPos());
			if (isOverlapping == false) {
				cubeGrid.Add(waypoint.GetGridPos(), waypoint);
				if (waypoint != startPoint || waypoint != endPoint) {
					//waypoint.SetTopColor(Color.clear);
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
