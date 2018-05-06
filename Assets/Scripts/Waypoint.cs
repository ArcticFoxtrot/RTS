using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	const int sizeOfGrid = 10;
	//waypoint needs to know it's own position -> calculate position on grid in waypoint script 

	Vector2Int gridPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		}

	public Vector2Int GetGridPos() {
		return new Vector2Int(
		Mathf.RoundToInt(transform.position.x / sizeOfGrid) * sizeOfGrid,
		Mathf.RoundToInt(transform.position.z / sizeOfGrid) * sizeOfGrid);
		}

	public int GetGridSize() {
		return sizeOfGrid;
		}

	public void SetTopColor(Color color) {
		//changes the color of the waypoint cube to sign start, goal and route
		MeshRenderer topFaceMeshRenderer = transform.Find("TopFace").GetComponent<MeshRenderer>();
		topFaceMeshRenderer.material.color = color;
		}

}
