﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropshadowDuplicate : MonoBehaviour {

	public Text mainText;
	public Text thisText;

	
	// Update is called once per frame
	void Update () {
		thisText.text = mainText.text;
	}
}
