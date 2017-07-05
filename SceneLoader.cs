using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private bool sceneLoaded = false;
	private bool scenesFinishedLoaded = false; 
	[Header ("Scene Names (Don't Add Scene To Load To)")]
	[SerializeField]
	private string[] sceneNames;
	[Header ("Scene To Load To")]
	[SerializeField] 
	private string sceneToLoadTo;
	[SerializeField]
	private Text loadingMessage;
	[SerializeField]
	private Text sillyText;
	[SerializeField]
	private string[] sillyTextMessages;

	//For Loading Bar:
	[SerializeField] 
	private Slider progressSlider;
	private float progressBarTotal = 1f;
	private float progressBarLoaded = 0f;

	void Start () {
		progressSlider.value = 0f;
	}

	void Update () {
		if (sceneLoaded == false) {
			sceneLoaded = true;
			loadingMessage.text = " ...";
			StartCoroutine (LoadScene ());
			StartCoroutine(ChangeSillyText());
		}
		if (sceneLoaded == true) {
			loadingMessage.color = new Color (loadingMessage.color.r, loadingMessage.color.g, loadingMessage.color.b, Mathf.PingPong (Time.time, 1));
			progressSlider.value = progressBarLoaded / progressBarTotal;
		}
	}

	IEnumerator LoadScene () {

		int sceneCounter = 0;
		foreach (string scene in sceneNames) {
			sceneCounter++;
			progressBarTotal = progressBarTotal + 2; 
		}

		yield return new WaitForSeconds (2);

		//Load Main Scene:
		AsyncOperation loadMainScene = SceneManager.LoadSceneAsync (sceneToLoadTo, LoadSceneMode.Additive);
		while (!loadMainScene.isDone) {
			yield return null;
		}
		progressBarLoaded++;


		//Load Each Scene:
		foreach (string scene in sceneNames) {
			AsyncOperation sceneLoader = SceneManager.LoadSceneAsync (scene, LoadSceneMode.Additive);
			while (!sceneLoader.isDone) {
				yield return null;
			}
			progressBarLoaded++;

		}

		//Kill Each Scene
		while (sceneCounter > 0) {
			AsyncOperation killScene = SceneManager.UnloadSceneAsync (sceneNames [sceneCounter - 1]);
			while (!killScene.isDone) {
				yield return null;
			}
			progressBarLoaded++;
			sceneCounter--;

		}

		//Load Main Scene:
		scenesFinishedLoaded = true; 
		AsyncOperation async = SceneManager.LoadSceneAsync (sceneToLoadTo, LoadSceneMode.Single);
		while (!async.isDone) {
			yield return null;
		}
	}

	IEnumerator ChangeSillyText () {
		while (!scenesFinishedLoaded) {
			int randomNumber = Random.Range (0, (sillyTextMessages.Length));
			Debug.Log(randomNumber);
			sillyText.text = sillyTextMessages [randomNumber];
			yield return new WaitForSeconds (2);

		}
	}
}
