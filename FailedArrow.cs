using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedArrow : MonoBehaviour {

	private GameObject failedArrowFallPoints;
	private Transform[] waypoint;
	private Transform currentWaypointGoal;
	private Vector3 currentPosition;
	private Vector3 destinationToFlyTo;

	private int waypointCounter = 1;

	private bool reachedDestination;

	public float speed;
	private float trueSpeed;


	void Start () {
		failedArrowFallPoints = GameObject.Find ("FailedArrowFallPoints");
		waypoint = failedArrowFallPoints.GetComponentsInChildren<Transform> ();
	}

	void Update () {
		trueSpeed = speed * Time.deltaTime;
		currentPosition = transform.position;
		currentWaypointGoal = waypoint [waypointCounter]; 
		Vector3 destinationToFlyTo = currentWaypointGoal.position; 

		float distanceToTarget = calculateDistanceToTarget (currentWaypointGoal);


		Flying (destinationToFlyTo, currentWaypointGoal); 

		if (distanceToTarget > 0.5f) {
			reachedDestination = false;
		} else {
			reachedDestination = true; 
		}


		if (reachedDestination && waypointCounter < (waypoint.Length - 1)) {
			waypointCounter++;
			reachedDestination = false; 
		} 

		if (reachedDestination && waypointCounter == (waypoint.Length - 1)) {
			Destroy (gameObject);
		}
	}


	private float calculateDistanceToTarget (Transform destination) {
		float distanceToTarget = Vector3.Distance (currentPosition, destination.position); 
		return distanceToTarget;
	}

	private void Flying (Vector3 waypoint, Transform currentWaypointGoal) {

		Vector3 targetDir = currentWaypointGoal.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, trueSpeed, 0);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (currentPosition, waypoint, (trueSpeed)); 

	}

}

