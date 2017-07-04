using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBScript : MonoBehaviour, IVirtualButtonEventHandler {


	private GameObject vbButtonObject;
	// Use this for initialization
	[SerializeField]
	AudioSource audioClip;

	void Start () {
		vbButtonObject = GameObject.Find("actionButton"); 
		vbButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler (this);
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb) {

	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb) {

	}


}
