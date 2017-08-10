using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OwlMovement : MonoBehaviour {

	//For Flying Motion:
	public bool isFlying = false;
	private bool reachedDestination = false;

	//For Calculating Distances Between Waypoints
	public Transform[] waypoint;
	private Transform currentWaypointGoal;
	private Vector3 currentPosition;

	//For Switching To Next Waypoints:
	private int waypointCounter = 0;

	//for making baby disappear
	public int waypointCounterWhenBabyDisappears;
	public GameObject babyGameObject;

	//For Controlling Speed within Script
	public float speed;
	private float trueSpeed;

	//For Controlling Liftoff animation
	private bool isLiftOff = false;
	public Animator animator;


	void Update () {
		trueSpeed = speed * Time.deltaTime;
		currentPosition = transform.position;
		currentWaypointGoal = waypoint [waypointCounter]; 


		if (isFlying) {
			Vector3 destinationToFlyTo = currentWaypointGoal.position; 
			float distanceToTarget = calculateDistanceToTarget (currentWaypointGoal);

			if (distanceToTarget > 0 && !isLiftOff) {
				animator.SetTrigger ("startFlying"); 
				isLiftOff = true; 
			}

			if (isLiftOff) {
				Flying (destinationToFlyTo, currentWaypointGoal); 
				if (distanceToTarget > 0.5f) {
					reachedDestination = false;
				} else {
					reachedDestination = true; 
				}
			}
		}

		if (waypointCounter == waypointCounterWhenBabyDisappears) {
			babyGameObject.SetActive (false); 

		}

		if (reachedDestination && waypointCounter < (waypoint.Length - 1)) {
			waypointCounter++;
			reachedDestination = false; 
		} 

		if (reachedDestination && waypointCounter == (waypoint.Length - 1)) {
			Destroy(gameObject);
		}
	}

	private void Flying (Vector3 waypoint, Transform currentWaypointGoal) {

		Vector3 targetDir = currentWaypointGoal.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, trueSpeed, 0);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (currentPosition, waypoint, (trueSpeed)); 
	}

	private float calculateDistanceToTarget (Transform destination) {
		float distanceToTarget = Vector3.Distance (currentPosition, destination.position); 
		return distanceToTarget;
	}

}
