using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour {

	public bool targetAlreadyLoaded;
	public string sceneLoaded;


	void Update () {
		if (!targetAlreadyLoaded) {
			sceneLoaded = null;
		}
	}
}
