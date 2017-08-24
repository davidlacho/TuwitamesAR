using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsikwaSwingObjects : MonoBehaviour {

	public Transform handTranform;
	public GameObject shawl;
	public GameObject apron;
	public GameObject paintBag;

	public void throwShawl () {
		Instantiate (shawl, handTranform.position, handTranform.rotation);
	}

	public void throwApron () {
		Instantiate (apron, handTranform.position, handTranform.rotation);
	}

	public void throwPaintBag () {
		Instantiate (paintBag, handTranform.position, handTranform.rotation);
	}

}

