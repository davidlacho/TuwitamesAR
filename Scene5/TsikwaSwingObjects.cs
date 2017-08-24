using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsikwaSwingObjects : MonoBehaviour {

	public Transform InstantiatePoint;
	private GameObject throwingObject; 

	public void throwShawl () {
		Instantiate (Resources.Load("shawl"), InstantiatePoint.position, InstantiatePoint.rotation);
	}

	public void throwApron () {
		Instantiate (Resources.Load("Apron"), InstantiatePoint.position, InstantiatePoint.rotation);
	}

	public void throwPaintBag () {
		Instantiate (Resources.Load("PaintBag"), InstantiatePoint.position, InstantiatePoint.rotation);
	}

}

