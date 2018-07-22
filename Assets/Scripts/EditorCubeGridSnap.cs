using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class EditorCubeGridSnap: MonoBehaviour {

	[SerializeField] Waypoint startPoint;
	[SerializeField] Waypoint endPoint;

	private TextMesh labelMesh;
	private Vector3 gridPosition;
	private Waypoint cubeWaypoint;
	private int sizeOfGrid;


	//Awake is called when played
	//Update is called when editing
	// Use this for initialization
	void Awake () {
		labelMesh = GetComponentInChildren<TextMesh>();
		cubeWaypoint = GetComponent<Waypoint>();
		sizeOfGrid = cubeWaypoint.GetGridSize();
	
		
	}
	
	// Update is called once per frame
	void Update () {
		SnapCubeToGrid();
		UpdateLabel();
		}

	private void SnapCubeToGrid() {
		gridPosition.x = cubeWaypoint.GetGridPos().x * sizeOfGrid;
		gridPosition.z = cubeWaypoint.GetGridPos().y * sizeOfGrid;
		transform.position = new Vector3(gridPosition.x, 0f, gridPosition.z);
		}

	private void UpdateLabel() {
		string cubeCoordinates = cubeWaypoint.GetGridPos().x + "," + cubeWaypoint.GetGridPos().y;
		if (labelMesh) { labelMesh.text = cubeCoordinates; }
		gameObject.name = "Cube " + cubeCoordinates;
		}
	}
