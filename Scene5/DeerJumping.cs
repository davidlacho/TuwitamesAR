using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerJumping : MonoBehaviour {

	public GameObject[] jumpPoints;
	private Vector3 currentPosition;
	private Transform currentJumpPointGoal;
	private Vector3 destinationToJumpTo;
	public int currentJumpPointNumber;
	private bool reachedDestination;
	public float speed;
	private float trueSpeed;
	public float distanceToTarget;


	void Update () {

		trueSpeed = speed * Time.deltaTime;
		currentPosition = transform.position;
		currentJumpPointGoal = jumpPoints[currentJumpPointNumber].transform;
		destinationToJumpTo = currentJumpPointGoal.position;
		distanceToTarget = calculateDistanceToTarget (currentJumpPointGoal);
		jumpingToJumpPoint (destinationToJumpTo, currentJumpPointGoal);

		if (distanceToTarget > 0.5) {
			reachedDestination = false;
		} else {
			reachedDestination = true; 
		}

		if (reachedDestination && currentJumpPointNumber < (jumpPoints.Length - 1)) {
			currentJumpPointNumber++;
			reachedDestination = false; 
		} 

		if (reachedDestination && currentJumpPointNumber == (jumpPoints.Length - 1)) {
			currentJumpPointNumber = 0;
		}

	}

	private float calculateDistanceToTarget (Transform destination) {
		float distanceToTarget = Vector3.Distance (currentPosition, destination.position); 
		return distanceToTarget;
	}


	private void jumpingToJumpPoint (Vector3 waypoint, Transform currentWaypointGoal) {

		Vector3 targetDir = currentWaypointGoal.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, trueSpeed, 0);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (currentPosition, waypoint, (trueSpeed)); 
	}

}



