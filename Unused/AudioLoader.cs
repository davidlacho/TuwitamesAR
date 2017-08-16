using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoader : MonoBehaviour {

	private AudioClip audioclip;

	public AudioClip DownloadAudio(string uri, string AudioName){
		Debug.Log("AudioLoader initialized");
		WWW www = new WWW (uri);
		StartCoroutine(WaitForReq(www, AudioName));
		return audioclip;

	}

	IEnumerator WaitForReq (WWW www, string AudioName) {
		Debug.Log("WaitForReq ran for " + AudioName);
		yield return www;
		AssetBundle bundle = www.assetBundle;
		if (www.error == "") {
			audioclip = (AudioClip)bundle.LoadAsset (AudioName) as AudioClip;
		} else {
			Debug.Log(www.error); 
		}
	}

}
