using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;

public class Salsa_Event : MonoBehaviour {

	private Salsa3D salsa;
	public AudioClip audioFile; 

	public void PlayAudioFile (AudioClip audioFile) {
		salsa.SetAudioClip(audioFile);
		salsa.Play(); 
	}

	public void StopAudioFile () {
		salsa.Stop();
	}



	void Salsa_OnTalkStatusChanged (SalsaStatus status) {

		if (status.instance.GetType () == typeof(Salsa3D)) {
			Debug.Log ("Salsa3D"); 
		} else {
			Debug.Log ("Salsa2D");
		}

	Debug.Log("Salsa_OnTalkStatusChanged:" +
		" instance(" + status.instance.GetType() + ")," +
		" talkerName(" + status.talkerName + ")," + 
		((status.isTalking) ? "started" : "finished") + " saying " + status.clipName);
}

}
