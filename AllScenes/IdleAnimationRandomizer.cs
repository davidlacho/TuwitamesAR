using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationRandomizer : MonoBehaviour {

	void RandomizeIdleStance () {
		Animator animator = GetComponent<Animator> ();
		int randomNumber = Random.Range (1, 5);
		animator.SetTrigger("Idle" + randomNumber);
	}
}
