using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnboardingHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnboardingComplete () {
		PlayerPrefs.SetInt("FirstLoad", 1);
		StartCoroutine(GoToLoadingScene());
	}

	IEnumerator GoToLoadingScene () {
		AsyncOperation async = SceneManager.LoadSceneAsync ("LoadingScene", LoadSceneMode.Single);
		while (!async.isDone) {
			yield return null;
		}
	}
}
