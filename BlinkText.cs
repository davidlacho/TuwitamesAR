using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.color = new Color (text.color.r, text.color.g, text.color.b, Mathf.PingPong (Time.time, 1));
	}
}
