using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EditorCubeGridSnap: MonoBehaviour {

	//Range restricts values in inspector, SizeOfGrid related to the size of the cube that needs to be snapped
	[SerializeField] [Range(1f, 20f)] float sizeOfGrid = 10f;

	private TextMesh labelMesh;

	//Awake is called when played
	//Update is called when editing
	// Use this for initialization
	void Awake () {
		labelMesh = GetComponentInChildren<TextMesh>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 snapPos;
		snapPos.x = Mathf.RoundToInt(transform.position.x / sizeOfGrid) * sizeOfGrid;
		snapPos.z = Mathf.RoundToInt(transform.position.z / sizeOfGrid) * sizeOfGrid;

		transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

		labelMesh.text = snapPos.x /sizeOfGrid + "," + snapPos.z / sizeOfGrid;
		}
}
