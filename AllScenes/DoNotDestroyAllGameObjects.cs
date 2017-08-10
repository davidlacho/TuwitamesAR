using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyAllGameObjects : MonoBehaviour {

	GameObject[] newGameObjects;

	void Update () {
		newGameObjects = FindObjectsOfType<GameObject>();

		foreach (GameObject gameobj in newGameObjects) {
			gameobj.AddComponent<DoNotDestroyOnLoad>();
		}
		Destroy(gameObject);
	}

}
