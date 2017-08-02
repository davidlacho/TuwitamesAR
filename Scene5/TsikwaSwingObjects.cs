using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsikwaSwingObjects : MonoBehaviour {

	public GameObject shawl;
	public GameObject apron;
	public GameObject paintBag;

	public void throwShawl () {
		Instantiate (shawl, transform.position, transform.rotation);
	}

	public void throwApron () {
		Instantiate (apron, transform.position, transform.rotation);
	}

	public void throwPaintBag () {
		Instantiate (paintBag, transform.position, transform.rotation);
	}

}

