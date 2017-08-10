using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoints : MonoBehaviour {

	private Transform[] jumpPointHeights;

	public void JumpHigh () {
		jumpPointHeights = GameObject.Find ("JumpPointHeights").GetComponentsInChildren<Transform> ();
		int height = 16;
		foreach (Transform point in jumpPointHeights) {
			point.position = new Vector3(point.position.x, height, point.position.z); 
		}
	}

	public void JumpHalf () {
		jumpPointHeights = GameObject.Find ("JumpPointHeights").GetComponentsInChildren<Transform> ();
		int height = 10;
		foreach (Transform point in jumpPointHeights) {
			point.position = new Vector3(point.position.x, height, point.position.z); 
		}
	}

	public void JumpQuarter () {
		jumpPointHeights = GameObject.Find ("JumpPointHeights").GetComponentsInChildren<Transform> ();
		int height = 8;
		foreach (Transform point in jumpPointHeights) {
			point.position = new Vector3(point.position.x, height, point.position.z); 
		}
	}

	public void JumpRegular() {
		jumpPointHeights = GameObject.Find ("JumpPointHeights").GetComponentsInChildren<Transform> ();
		int height = 4;
		foreach (Transform point in jumpPointHeights) {
			point.position = new Vector3(point.position.x, height, point.position.z); 
		}
	}






}
