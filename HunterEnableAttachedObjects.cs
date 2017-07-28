using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterEnableAttachedObjects : MonoBehaviour {


	public GameObject bow;

	public GameObject leftHandArrow;

	public GameObject rightHandArrow;

	public GameObject failedArrow;

	public GameObject availableObjects;

	void Update() {
		Destroy(availableObjects);
	}

	public void BowEnabled () {
		bow.SetActive (true);
	}

	public void BowDisabled () {
		bow.SetActive (false);
	}

	public void LeftHandArrowEnabled () {
		leftHandArrow.SetActive (true);
	}

	public void LeftHandArrowDisabled () {
		leftHandArrow.SetActive (false);
	}

	public void RightHandArrowEnabled () {
		rightHandArrow.SetActive (true);
	}

	public void RightHandArrowDisabled () {
		rightHandArrow.SetActive(false);
	}

	public void failedArrowEnabled () {
		failedArrow.SetActive(true);
	}

}
