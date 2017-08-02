using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tsikwaObjectMove : MonoBehaviour {
	private GameObject tsikwasObject;
	public GameObject hitPointObject;
	private Transform objectHitTransformGoal;
	private Vector3 currentPosition;
	private Vector3 destinationToFlyTo;
	private bool reachedDestination;
	private float distanceToTarget;
	public float speed;
	private float trueSpeed;
	public GameObject jumpPointHeightsHolder;
	public Transform[] jumpPointHeights;
	public float reduceJumpPointHeightByThisAmount;

	public bool isApron;
	public bool isShawl;
	public bool isPaintBag;

	void Start () {

		if (isApron) {
			hitPointObject = GameObject.Find ("ApronFallPoint");
		}
		if (isShawl) {
			hitPointObject = GameObject.Find ("ShawlFallPoint");
		}
		if (isPaintBag) {
			hitPointObject = GameObject.Find ("PaintBagFallPoint");
		}

		if (hitPointObject == null) {
			Destroy (gameObject);
			Debug.Log ("hitPointObject not found, object destroyed");
		}


		objectHitTransformGoal = hitPointObject.GetComponent<Transform> ();
		jumpPointHeightsHolder = GameObject.Find ("JumpPointHeights");
		jumpPointHeights = jumpPointHeightsHolder.GetComponentsInChildren<Transform> ();
	}

	void Update () {
		trueSpeed = speed * Time.deltaTime;
		currentPosition = gameObject.transform.position;
		destinationToFlyTo = objectHitTransformGoal.position;
		distanceToTarget = calculateDistanceToTarget (objectHitTransformGoal);
		Flying (destinationToFlyTo, objectHitTransformGoal);

		if (distanceToTarget > 0.5f) {
			reachedDestination = false;
		} else {
			Destroy (gameObject);
			foreach (Transform jumpPointHeight in jumpPointHeights) {
				jumpPointHeight.position = new Vector3 (jumpPointHeight.position.x, (jumpPointHeight.position.y - reduceJumpPointHeightByThisAmount), jumpPointHeight.position.z);
			}
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
