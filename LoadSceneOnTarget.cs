using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadSceneOnTarget : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	public string sceneName;
	private bool sceneLoaded = false;
	private AudioSource audioHolderSource;
	private Text LoadingText;

	[Header ("Audio & Speaker Settings")]
	public bool isSalsaChar;
	public AudioClip charAudioClip;
	public bool primarySpeaker;
	public bool secondarySpeaker;
	public bool tertiarySpeaker;
	public bool quaternarySpeaker;

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

	private GameObject primarySpeakerController;
	private GameObject secondarySpeakerController;
	private GameObject tertiarySpeakerController;
	private GameObject quaternarySpeakerController;

	void Update () {
		LoadingText.text = null;
	}

	void Start () {

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
			primarySpeakerController = GameObject.Find ("PrimarySpeakerController");
			audioHolderSource = GameObject.Find ("PrimarySpeakerController").GetComponent<AudioSource> ();
		} 

		if (secondarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			quaternarySpeaker = false;
			audioHolderSource = GameObject.Find ("SecondarySpeakerController").GetComponent<AudioSource> ();
		}

		if (tertiarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			quaternarySpeaker = false;
			audioHolderSource = GameObject.Find ("TertiarySpeakerController").GetComponent<AudioSource> ();
		}

		if (quaternarySpeaker) {
			primarySpeaker = false;
			tertiarySpeaker = false;
			secondarySpeaker = false;
			audioHolderSource = GameObject.Find ("QuaternarySpeakerController").GetComponent<AudioSource> ();
		}

		//Vuforia Target Tracking:

		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}

	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			//If a target is found:
			StartCoroutine (LoadingLevel ()); 
			CharacterPresentChecks ();
			SALSAChecks ();
			audioHolderSource.clip = charAudioClip;
			sceneLoaded = true;
			if (SECW_Subtitles && AudioClipSubtitleENG != null) {
				SubtitleObject.text = AudioClipSubtitleSECW;
			} else if (AudioClipSubtitleENG != null) {
				SubtitleObject.text = AudioClipSubtitleENG;
			}

		} else {
			if (sceneLoaded) {
				//When a target is "lost"
				ResetSALSAOnClose ();
				audioHolderSource.clip = null;
				sceneLoaded = false;
				SubtitleObject.text = null;
				StartCoroutine (KillScene ());
			}
		}
	}

	public IEnumerator LoadingLevel () {
		AsyncOperation loadingScene = SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
		while (!loadingScene.isDone) {
			LoadingText.text = "Loading...";
			yield return null;
		}

	}

	public IEnumerator KillScene () {
		AsyncOperation killScene = SceneManager.UnloadSceneAsync (sceneName);
		while (!killScene.isDone) {
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
	}

	public void ResetSALSAOnClose () {
		GameObject.Find ("PrimarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("SecondarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("TertiarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
		GameObject.Find ("QuaternarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar = false;
	}
}
