using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(transform.gameObject); 
	}

}
