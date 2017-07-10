using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlMovement : MonoBehaviour {

	// Move owl along a series of waypoints with different animations

	// 1. Look around
	// 2. Pick up to fly off
	// 3. Fly to waypoints, rotating accordingly.
	// 4. Pick up Baby Game Object
	// 5. Fly away


	//For Flying Motion:
	public bool isFlying = false;
	private bool reachedDestination = false;


	//For Calculating Distances Between Waypoints
	public Transform[] waypoint;
	public float timeToNextWaypoint;
	private Transform currentWaypointGoal;
	private Vector3 currentPosition;
	[SerializeField] 
	private float distanceFromWaypointBeforeSwitch; // Choose the distance from the waypoint that the gameobject will change to the next waypioint

	//For Switching To Next Waypoints:
	private int waypointCounter = 0;
	public float speed;

	void Update () {
		currentPosition = transform.position;
		Debug.Log (reachedDestination); 
		currentWaypointGoal = waypoint[waypointCounter]; 


		if (isFlying) {
			Vector3 destinationToFlyTo = currentWaypointGoal.position; 
			float distanceToTarget = calculateDistanceToTarget (currentWaypointGoal);
			Flying (destinationToFlyTo); 
			if (distanceToTarget > distanceFromWaypointBeforeSwitch) {
				reachedDestination = false;
			} else {
				reachedDestination = true; 
			}
		}

		if (reachedDestination && waypointCounter < (waypoint.Length - 1)) {
		 	waypointCounter++;
			reachedDestination = false; 
		}
	}

	private void Flying (Vector3 waypoint) {
		transform.LookAt(waypoint); 
		transform.position = Vector3.MoveTowards (currentPosition, waypoint, (Time.deltaTime * speed)); 
	}

	private float calculateDistanceToTarget (Transform destination) {
		float distanceToTarget = Vector3.Distance (currentPosition, destination.position); 
		Debug.Log(distanceToTarget); 
		return distanceToTarget;
	}

}
