using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFlying : MonoBehaviour {

	//For Flying Motion:
	private bool reachedLandDestination = false;
	private bool reachedTakeoffDestination = false;

	//For Calculating Distances Between Waypoints
	public Transform[] LandingWaypoints;
	public Transform[] TakeoffWaypoints;
	private Transform currentWaypointGoal;
	private Vector3 currentPosition;

	//For Switching To Next Waypoints:
	private int landingWaypointCounter = 0;
	private int takeoffWaypointCounter = 0;

	//For Controlling Speed within Script
	public float speed;
	private float trueSpeed;

	//For Controlling Liftoff animation
	private bool isFlyingToLand = false;
	private bool isFlyingToTakeoff = false;
	private Animator animator;

	//For Controlling Landing Animation:
	private bool isLanded = false;

	public bool landingEagle = false;
	public bool takeoffEagle = false;

	void Start () {
		animator = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		trueSpeed = speed * Time.deltaTime;
		currentPosition = transform.position;

		if (landingEagle) {
			currentWaypointGoal = LandingWaypoints [landingWaypointCounter]; 

			Vector3 destinationToFlyTo = currentWaypointGoal.position; 
			float distanceToTarget = calculateDistanceToTarget (currentWaypointGoal);

			if (distanceToTarget > 0 && !isFlyingToLand) {
				isFlyingToLand = true; 
			}

			if (isFlyingToLand) {
				Flying (destinationToFlyTo, currentWaypointGoal); 
				if (distanceToTarget > 0.5f) {
					reachedLandDestination = false;
				} else {
					reachedLandDestination = true; 
				}
			}

			if (reachedLandDestination && landingWaypointCounter < (LandingWaypoints.Length - 1)) {
				landingWaypointCounter++;
				reachedLandDestination = false; 
			} 

			if (reachedLandDestination && landingWaypointCounter == (LandingWaypoints.Length - 1)) {
				if (!isLanded) {
					animator.SetTrigger ("Land");
					isLanded = true;
				}
			}
		}

		if (takeoffEagle) {
			currentWaypointGoal = TakeoffWaypoints [takeoffWaypointCounter]; 
			Vector3 destinationToFlyTo = currentWaypointGoal.position; 
			float distanceToTarget = calculateDistanceToTarget (currentWaypointGoal);

			if (distanceToTarget > 0 && !isFlyingToTakeoff) {
				isFlyingToTakeoff = true; 
				animator.SetTrigger ("Takeoff");
			}

			if (isFlyingToTakeoff) {
				Flying (destinationToFlyTo, currentWaypointGoal); 
				if (distanceToTarget > 0.5f) {
					reachedTakeoffDestination = false;
				} else {
					reachedTakeoffDestination = true; 
				}
			}

			if (reachedTakeoffDestination && takeoffWaypointCounter < (TakeoffWaypoints.Length - 1)) {
				takeoffWaypointCounter++;
				reachedTakeoffDestination = false; 
			} 

			if (reachedTakeoffDestination && takeoffWaypointCounter == (TakeoffWaypoints.Length - 1)) {
				Destroy(gameObject);
			}
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
