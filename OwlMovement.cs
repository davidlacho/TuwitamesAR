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

	public bool isFlying = false;

	public Transform[] waypoint;
	public float timeToNextWaypoint;
	private Transform currentWaypointGoal;
	private Vector3 currentPosition;
	[SerializeField] 
	private float distanceFromWaypointBeforeSwitch; // Choose the distance from the waypoint that the gameobject will change to the next waypioint
	public bool reachedDestination = false;
	private int waypointCounter = 0;

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
		transform.position = Vector3.Lerp (currentPosition, waypoint, Time.deltaTime); 
	}

	private float calculateDistanceToTarget (Transform destination) {
		float distanceToTarget = Vector3.Distance (currentPosition, destination.position); 
		Debug.Log(distanceToTarget); 
		return distanceToTarget;
	}

}
