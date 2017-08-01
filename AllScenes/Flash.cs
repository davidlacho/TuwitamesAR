using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Flash : MonoBehaviour {


	private bool flash = false;

	public void onFlashButtonDown () {

		if (!flash) {
			CameraDevice.Instance.SetFlashTorchMode (true);
			flash = true;
		} else {
			CameraDevice.Instance.SetFlashTorchMode(false);
			flash = false;
		}

	}

}
