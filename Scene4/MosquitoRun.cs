﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoRun : MonoBehaviour {

	public float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}
}
