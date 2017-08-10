using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadSceneOnTarget : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	public string sceneName;
	private bool sceneLoaded;
	private string currentTargetName = null;
	private AudioSource audioHolderSource;
	private Text LoadingText;
	private GameObject targetManager;

	//Target Manager:
	private bool anotherTargetAlreadyLoaded;
	private string sceneAlreadyLoadedInTargetManager;



	[Header ("Audio & Speaker Settings")]
	public bool isSalsaChar;
	public AudioClip charAudioClip;
	public bool primarySpeaker;
	public bool secondarySpeaker;
	public bool tertiarySpeaker;
	public bool quaternarySpeaker;
	public bool quinarySpeaker;
	public bool senarySpeaker;
	public bool septenarySpeaker;
	public bool octonarySpeaker;

	[Header ("Subtitle Settings")]
	private Text SubtitleObject;
	public string AudioClipSubtitleENG;
	public string AudioClipSubtitleSECW;
	public bool SECW_Subtitles;

	[Header ("Character Controllers")]
	public bool char1Present;
	public string char1AnimationTrigger = null;
	public bool char2Present;
	public string char2AnimationTrigger = null;
	public bool char3Present;
	public string char3AnimationTrigger = null;
	public bool char4Present;
	public string char4AnimationTrigger = null;
	public bool char5Present;
	public string char5AnimationTrigger = null;
	public bool char6Present;
	public string char6AnimationTrigger = null;
	public bool char7Present;
	public string char7AnimationTrigger = null;
	public bool char8Present;
	public string char8AnimationTrigger = null;
	public bool char9Present;
	public string char9AnimationTrigger = null;
	public bool char10Present;
	public string char10AnimationTrigger = null;
	public bool char11Present;
	public string char11AnimationTrigger = null;
	public bool char12Present;
	public string char12AnimationTrigger = null;

	private GameObject primarySpeakerController;
	private GameObject secondarySpeakerController;
	private GameObject tertiarySpeakerController;
	private GameObject quaternarySpeakerController;
	private GameObject quinarySpeakerController;
	private GameObject senarySpeakerController;
	private GameObject septenarySpeakerController;
	private GameObject octonarySpeakerController;

	void Update () {

		anotherTargetAlreadyLoaded = targetManager.GetComponent<TargetManager> ().targetAlreadyLoaded;
		sceneAlreadyLoadedInTargetManager = targetManager.GetComponent<TargetManager> ().sceneLoaded;

		LoadingText.text = null;
		if (SECW_Subtitles && AudioClipSubtitleENG != null && sceneLoaded) {
			SubtitleObject.text = AudioClipSubtitleSECW;
		} else if (AudioClipSubtitleENG != null && sceneLoaded) {
			SubtitleObject.text = AudioClipSubtitleENG;
		}
	}



	void Start () {
		targetManager = GameObject.Find ("TargetManager");
		sceneLoaded = false;
	
		//For Loading Image
		LoadingText = GameObject.Find ("loadingText").GetComponent<Text> ();
		LoadingText.text = null;
		//Finds Subtitle Object
		SubtitleObject = GameObject.Find ("subtitleText").GetComponent<Text> ();

		//Speaker Checks:
		if (primarySpeaker) {
			secondarySpeaker = false;
			tertiarySpeaker = false;
			quaternarySpeaker = false;
			quinarySpeaker = false;
			senarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeaker = false;
			primarySpeakerController = GameObject.Find ("PrimarySpeakerController");
			audioHolderSource = primarySpeakerController.GetComponent<AudioSource> ();
		} 

		if (secondarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			quaternarySpeaker = false;
			quinarySpeaker = false;
			senarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeaker = false;
			secondarySpeakerController = GameObject.Find ("SecondarySpeakerController");
			audioHolderSource = secondarySpeakerController.GetComponent<AudioSource> ();
		}

		if (tertiarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			quaternarySpeaker = false;
			quinarySpeaker = false;
			senarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeaker = false;
			tertiarySpeakerController = GameObject.Find ("TertiarySpeakerController");
			audioHolderSource = tertiarySpeakerController.GetComponent<AudioSource> ();
		}

		if (quaternarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			secondarySpeaker = false;
			quinarySpeaker = false;
			senarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeaker = false;
			quaternarySpeakerController = GameObject.Find ("QuaternarySpeakerController");
			audioHolderSource = quaternarySpeakerController.GetComponent<AudioSource> ();
		}

		if (quinarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			secondarySpeaker = false;
			quaternarySpeaker = false;
			senarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeaker = false;
			quinarySpeakerController = GameObject.Find ("QuinarySpeakerController");
			audioHolderSource = quinarySpeakerController.GetComponent<AudioSource> ();
		}

		if (senarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			secondarySpeaker = false;
			quaternarySpeaker = false;
			quinarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeaker = false;
			senarySpeakerController = GameObject.Find ("SenarySpeakerController");
			audioHolderSource = senarySpeakerController.GetComponent<AudioSource> ();
		}

		if (septenarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			secondarySpeaker = false;
			quaternarySpeaker = false;
			quinarySpeaker = false;
			senarySpeaker = false;
			octonarySpeaker = false;
			septenarySpeakerController = GameObject.Find ("SeptenarySpeakerController");
			audioHolderSource = septenarySpeakerController.GetComponent<AudioSource> ();
		}

		if (octonarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			secondarySpeaker = false;
			quaternarySpeaker = false;
			quinarySpeaker = false;
			senarySpeaker = false;
			septenarySpeaker = false;
			octonarySpeakerController = GameObject.Find ("OctonarySpeakerController");
			audioHolderSource = octonarySpeakerController.GetComponent<AudioSource> ();
		}

		//Vuforia Target Tracking:
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}

	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (!anotherTargetAlreadyLoaded && newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			//If a target is found:

			if (anotherTargetAlreadyLoaded && sceneAlreadyLoadedInTargetManager != null) {
				StartCoroutine (UnloadAlreadyLoadedScene ());
			}

			StartCoroutine (LoadingLevel ()); 
			CharacterPresentChecks ();
			SALSAChecks ();
			audioHolderSource.clip = charAudioClip;
			sceneLoaded = true;
			targetManager.GetComponent<TargetManager> ().targetAlreadyLoaded = true;
			targetManager.GetComponent<TargetManager> ().sceneLoaded = sceneName;
			currentTargetName = gameObject.transform.name;

		} else {
			//When a target is "lost"
			if (sceneLoaded) { 
				currentTargetName = null;
				ResetSALSAOnClose ();
				audioHolderSource.clip = null;
				sceneLoaded = false;
				SubtitleObject.text = null;
				targetManager.GetComponent<TargetManager> ().targetAlreadyLoaded = false;
				StartCoroutine (LoadToBlankScene ());
			}
		}
	}

	public IEnumerator UnloadAlreadyLoadedScene () {
		AsyncOperation unloadAlreadyLoadedScene = SceneManager.UnloadSceneAsync (sceneAlreadyLoadedInTargetManager);
		while (!unloadAlreadyLoadedScene.isDone) {
			LoadingText.text = "Loading...";
			yield return null;
		}
	}

	public IEnumerator LoadingLevel () {
		AsyncOperation loadingScene = SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
		while (!loadingScene.isDone) {
			LoadingText.text = "Loading...";
			yield return null;
		}

	}

	public IEnumerator LoadToBlankScene () {
		//AsyncOperation killScene = SceneManager.UnloadSceneAsync (sceneName);
		AsyncOperation loadToBlankScene = SceneManager.LoadSceneAsync ("LoadToScene", LoadSceneMode.Single);
		while (!loadToBlankScene.isDone) {
			yield return null;
		}
	}

	public void CharacterPresentChecks () {

		//Character Present Checks:
		if (char1Present) {
			GameObject.Find ("CharacterPresent_1").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_1").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char1AnimationTrigger;
		} else {
			GameObject.Find ("CharacterPresent_1").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char2Present) {
			GameObject.Find ("CharacterPresent_2").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_2").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char2AnimationTrigger;
		} else {
			GameObject.Find ("CharacterPresent_2").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char3Present) {
			GameObject.Find ("CharacterPresent_3").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_3").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char3AnimationTrigger;

		} else {
			GameObject.Find ("CharacterPresent_3").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char4Present) {
			GameObject.Find ("CharacterPresent_4").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_4").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char4AnimationTrigger;

		} else {
			GameObject.Find ("CharacterPresent_4").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char5Present) {
			GameObject.Find ("CharacterPresent_5").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_5").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char5AnimationTrigger;

		} else {
			GameObject.Find ("CharacterPresent_5").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char6Present) {
			GameObject.Find ("CharacterPresent_6").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_6").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char6AnimationTrigger;
		} else {
			GameObject.Find ("CharacterPresent_6").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char7Present) {
			GameObject.Find ("CharacterPresent_7").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_7").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char7AnimationTrigger;

		} else {
			GameObject.Find ("CharacterPresent_7").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char8Present) {
			GameObject.Find ("CharacterPresent_8").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_8").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char8AnimationTrigger; 
		} else {
			GameObject.Find ("CharacterPresent_8").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char9Present) {
			GameObject.Find ("CharacterPresent_9").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_9").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char9AnimationTrigger; 
		} else {
			GameObject.Find ("CharacterPresent_9").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char10Present) {
			GameObject.Find ("CharacterPresent_10").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_10").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char10AnimationTrigger; 
		} else {
			GameObject.Find ("CharacterPresent_10").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char11Present) {
			GameObject.Find ("CharacterPresent_11").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_11").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char11AnimationTrigger; 
		} else {
			GameObject.Find ("CharacterPresent_11").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}

		if (char12Present) {
			GameObject.Find ("CharacterPresent_12").GetComponent<CheckCharPresent> ().isCharPresent = true;
			GameObject.Find ("CharacterPresent_12").GetComponent<CheckCharPresent> ().characterAnimationTrigger = char12AnimationTrigger; 
		} else {
			GameObject.Find ("CharacterPresent_12").GetComponent<CheckCharPresent> ().isCharPresent = false;
		}
	}


	//Salsa Char Checks:

	public void SALSAChecks () {
		if (primarySpeaker && isSalsaChar) {
			GameObject.Find ("PrimarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		}

		if (secondarySpeaker && isSalsaChar) {
			GameObject.Find ("SecondarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 

		if (tertiarySpeaker && isSalsaChar) {
			GameObject.Find ("TertiarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 

		if (quaternarySpeaker && isSalsaChar) {
			GameObject.Find ("QuaternarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 

		if (quinarySpeaker && isSalsaChar) {
			GameObject.Find ("QuinarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 

		if (senarySpeaker && isSalsaChar) {
			GameObject.Find ("SenarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 

		if (septenarySpeaker && isSalsaChar) {
			GameObject.Find ("SeptenarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 

		if (octonarySpeaker && isSalsaChar) {
			GameObject.Find ("OctonarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = true;
		} 
	}

	public void ResetSALSAOnClose () {
		GameObject.Find ("PrimarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("SecondarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("TertiarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("QuaternarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("QuinarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("SenarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("SeptenarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("OctonarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
	}
}
