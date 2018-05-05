using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class EditorCubeGridSnap: MonoBehaviour {

	//Range restricts values in inspector, SizeOfGrid related to the size of the cube that needs to be snapped


	private TextMesh labelMesh;
	private string cubeCoordinates;
	private Vector3 gridPosition;
	private Waypoint cubeWaypoint;
	private int sizeOfGrid;


	//Awake is called when played
	//Update is called when editing
	// Use this for initialization
	void Awake () {
		labelMesh = GetComponentInChildren<TextMesh>();
		cubeWaypoint = GetComponent<Waypoint>();
		print(cubeWaypoint);
		sizeOfGrid = cubeWaypoint.GetGridSize();
		
	}
	
	// Update is called once per frame
	void Update () {
		SnapCubeToGrid();
		UpdateLabel();
		}

	private void SnapCubeToGrid() {
		gridPosition.x = cubeWaypoint.GetGridPos().x;
		gridPosition.z = cubeWaypoint.GetGridPos().y;
		transform.position = new Vector3(gridPosition.x, 0f, gridPosition.z);
		}

	private void UpdateLabel() {
		cubeCoordinates = gridPosition.x / sizeOfGrid + "," + gridPosition.z / sizeOfGrid;
		labelMesh.text = cubeCoordinates;
		gameObject.name = "Cube " + cubeCoordinates;
		}
	}
