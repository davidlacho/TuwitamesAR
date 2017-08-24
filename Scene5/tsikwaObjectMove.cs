using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tsikwaObjectMove : MonoBehaviour {
	//private GameObject tsikwasObject;

	private Vector3 currentPosition;
	private bool reachedDestination;
	public float speed = 15;
	private float trueSpeed;
	private float distanceToFlyToPoint;
	private bool pathChosen = false;

	public GameObject deer1;
	public GameObject deer2;
	public GameObject deer3; 
	public GameObject FlyToPoint;

	public bool isApron;
	public bool isShawl;
	public bool isPaintBag;

	void Start () {
		deer1 = GameObject.Find ("Deer1");
		deer2 = GameObject.Find ("Deer2");
		deer3 = GameObject.Find ("Deer3");
		FlyToPoint = GameObject.Find("FlyToPoint");
	}

	void Update () {
		trueSpeed = speed * Time.deltaTime;
		currentPosition = gameObject.transform.position;
		ObjectFlying (FlyToPoint.transform.position, FlyToPoint.transform);
		distanceToFlyToPoint = calculateDistanceToTarget(FlyToPoint.transform);

		if (distanceToFlyToPoint > 0.5f) {
			reachedDestination = false;
		} else {
			Destroy (gameObject);
			if (isApron) {
				deer3.GetComponent<Animator> ().SetTrigger ("JumpHalf");
				deer1.GetComponent<Animator> ().SetTrigger ("JumpHalf");
				deer2.GetComponent<Animator> ().SetTrigger ("JumpHalf");
			}
		}
		if (isShawl) {
			deer3.GetComponent<Animator> ().SetTrigger ("JumpQuarter");
			deer1.GetComponent<Animator> ().SetTrigger ("JumpQuarter");
			deer2.GetComponent<Animator> ().SetTrigger ("JumpQuarter");
		}
		if (isPaintBag) {
			deer1.GetComponent<Animator> ().SetTrigger ("JumpRegular");
			deer3.GetComponent<Animator> ().SetTrigger ("JumpRegular");
			deer2.GetComponent<Animator> ().SetTrigger ("JumpRegular");
		}
	}

	private float calculateDistanceToTarget (Transform destination) {
		float distanceToTarget = Vector3.Distance (currentPosition, destination.position); 
		return distanceToTarget;
	}

	private void ObjectFlying (Vector3 waypoint, Transform currentWaypointGoal) {
		Vector3 targetDir = currentWaypointGoal.position - transform.position;
		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, trueSpeed, 0);
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (currentPosition, waypoint, (trueSpeed)); 
	}
}
