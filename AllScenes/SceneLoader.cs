using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	private bool sceneLoaded = false;
	private bool scenesFinishedLoaded = false;
	[Header ("Initialization Scene To Load")]
	[SerializeField]
	private string[] scenesToLoad;
	[Header ("Scene To Load To After Initialization")]
	[SerializeField]
	private string sceneToLoadTo;

	[Header ("Loading Texts")]
	[SerializeField]
	private Text loadingMessage;
	[SerializeField]
	private Text sillyText;
	[SerializeField]
	private string[] sillyTextMessages;
	[SerializeField]
	private float changeSillyTextTiming;


	[Header ("For Loading Bar")]
	//For Loading Bar:
	[SerializeField] 
	private Slider progressSlider;
	private float progressBarTotal = 1f;
	private float progressBarLoaded = 0f;

	[Header ("Reset Player First Load for Onboarding (Requires Restart)")]
	public bool resetPlayerFirstLoad = false;
	//For Onboarding:
	private bool playerFirstLoad;


	[Header ("Loading Screen GameObjects to Destroy")]
	//Stuff to destroy when done:
	public GameObject[] LoadingSceneObjects;

	void Start () {
		progressSlider.value = 0f;
		progressBarTotal = scenesToLoad.Length + 1;

		if (PlayerPrefs.GetInt ("FirstLoad") == 0) {
			playerFirstLoad = true;
			Debug.Log("User First Load, Proceding to Onboard Screen");
		} else {
			playerFirstLoad = false;
			Debug.Log("Onboarding Complete, Loading Game");
		}

	

	}

	void Update () {
		if (resetPlayerFirstLoad) {
			resetPlayerFirstLoad = false;
			PlayerPrefs.SetInt("FirstLoad", 0);
		}

		if (playerFirstLoad) {
			StartCoroutine (LoadOnboardingScene());
		} else {
			if (sceneLoaded == false) {
				sceneLoaded = true;
				loadingMessage.text = " ...";
				StartCoroutine (LoadScene ());
				StartCoroutine (ChangeSillyText ());
			}
			if (sceneLoaded == true) {
				loadingMessage.color = new Color (loadingMessage.color.r, loadingMessage.color.g, loadingMessage.color.b, Mathf.PingPong (Time.time, 1));
				progressSlider.value = progressBarLoaded / progressBarTotal;
			}

		}

	}

	IEnumerator LoadOnboardingScene () {
		AsyncOperation async = SceneManager.LoadSceneAsync ("Onboarding", LoadSceneMode.Single);
		while (!async.isDone) {
			yield return null;
		}
	}

	IEnumerator LoadScene () {
		foreach (string scene in scenesToLoad) {
			AsyncOperation sceneLoader = SceneManager.LoadSceneAsync (scene, LoadSceneMode.Additive);
			while (!sceneLoader.isDone) {
				yield return null;
			}
			progressBarLoaded++;
		}

		//Load After Initialization:
		scenesFinishedLoaded = true; 
		progressBarLoaded++;
		AsyncOperation async = SceneManager.LoadSceneAsync (sceneToLoadTo, LoadSceneMode.Single);
		while (!async.isDone) {
			yield return null;
		}

		foreach (GameObject obj in LoadingSceneObjects) {
			GameObject.Destroy(obj);
		}
	}

	IEnumerator ChangeSillyText () {
		while (!scenesFinishedLoaded) {
			int randomNumber = Random.Range (0, (sillyTextMessages.Length));
			sillyText.text = sillyTextMessages [randomNumber];
			yield return new WaitForSeconds (changeSillyTextTiming);

		}
	}
}
