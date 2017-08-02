﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;

public class SceneCharacterManager : MonoBehaviour {

	[Header ("Characters")]
	public GameObject character1;
	public GameObject character2;
	public GameObject character3;
	public GameObject character4;
	public GameObject character5;
	public GameObject character6;
	public GameObject character7;
	public GameObject character8;
	public GameObject character9;
	public GameObject character10;
	public GameObject character11;
	public GameObject character12;

	[Header ("Speakers")]
	public GameObject primarySpeaker;
	private Salsa3D primarySpeakerSALSA3D;
	private GameObject primarySpeakerController;
	private AudioSource fetchedPrimarySpeakerAudioSource;
	private AudioSource primarySpeakerAudioSource;
	private bool primarySpeakerIsSalsaChar;

	public GameObject secondarySpeaker;
	private Salsa3D secondarySpeakerSALSA3D;
	private GameObject secondarySpeakerController;
	private AudioSource fetchedSecondarySpeakerAudioSource;
	private AudioSource secondarySpeakerAudioSource;
	private bool secondarySpeakerIsSalsaChar;

	public GameObject tertiarySpeaker;
	private Salsa3D tertiarySpeakerSALSA3D;
	private GameObject tertiarySpeakerController;
	private AudioSource fetchedTertiarySpeakerAudioSource;
	private AudioSource tertiarySpeakerAudioSource;
	private bool tertiarySpeakerIsSalsaChar;

	public GameObject quaternarySpeaker;
	private Salsa3D quaternarySpeakerSALSA3D;
	private GameObject quaternarySpeakerController;
	private AudioSource fetchedQuaternarySpeakerAudioSource;
	private AudioSource quaternarySpeakerAudioSource;
	private bool quaternarySpeakerIsSalsaChar;

	void Start () {


		// Character Present Checks and Sets Animators: 

		if (character1 != null) {
			if (GameObject.Find ("CharacterPresent_1").GetComponent<CheckCharPresent> ().isCharPresent) {
				character1.SetActive (true);
				Animator charAnimator1 = character1.GetComponent<Animator> ();
				if (charAnimator1 != null) {
					charAnimator1.SetTrigger (GameObject.Find ("CharacterPresent_1").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character1);
			}
		}

		if (character2 != null) {
			if (GameObject.Find ("CharacterPresent_2").GetComponent<CheckCharPresent> ().isCharPresent) {
				character2.SetActive (true);
				Animator charAnimator2 = character2.GetComponent<Animator> ();
				if (charAnimator2 != null) {
					charAnimator2.SetTrigger (GameObject.Find ("CharacterPresent_2").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character2);
			}
		}

		if (character3 != null) {
			if (GameObject.Find ("CharacterPresent_3").GetComponent<CheckCharPresent> ().isCharPresent) {
				character3.SetActive (true);
				Animator charAnimator3 = character3.GetComponent<Animator> ();
				if (charAnimator3 != null) {
					charAnimator3.SetTrigger (GameObject.Find ("CharacterPresent_3").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character3);
			}
		}

		if (character4 != null) {
			if (GameObject.Find ("CharacterPresent_4").GetComponent<CheckCharPresent> ().isCharPresent) {
				character4.SetActive (true);
				Animator charAnimator4 = character4.GetComponent<Animator> ();
				if (charAnimator4 != null) {
					charAnimator4.SetTrigger (GameObject.Find ("CharacterPresent_4").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character4);
			}
		}

		if (character5 != null) {
			if (GameObject.Find ("CharacterPresent_5").GetComponent<CheckCharPresent> ().isCharPresent) {
				character5.SetActive (true);
				Animator charAnimator5 = character5.GetComponent<Animator> ();
				if (charAnimator5 != null) {
					charAnimator5.SetTrigger (GameObject.Find ("CharacterPresent_5").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character5);
			}
		}

		if (character6 != null) {
			if (GameObject.Find ("CharacterPresent_6").GetComponent<CheckCharPresent> ().isCharPresent) {
				character6.SetActive (true);
				Animator charAnimator6 = character6.GetComponent<Animator> ();
				if (charAnimator6 != null) {
					charAnimator6.SetTrigger (GameObject.Find ("CharacterPresent_6").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character6);
			}
		}

		if (character7 != null) {
			if (GameObject.Find ("CharacterPresent_7").GetComponent<CheckCharPresent> ().isCharPresent) {
				character7.SetActive (true);
				Animator charAnimator7 = character7.GetComponent<Animator> ();
				if (charAnimator7 != null) {
					charAnimator7.SetTrigger (GameObject.Find ("CharacterPresent_7").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character7);
			}
		}

		if (character8 != null) {
			if (GameObject.Find ("CharacterPresent_8").GetComponent<CheckCharPresent> ().isCharPresent) {
				character8.SetActive (true);
				Animator charAnimator8 = character8.GetComponent<Animator> ();
				if (charAnimator8 != null) {
					charAnimator8.SetTrigger (GameObject.Find ("CharacterPresent_8").GetComponent<CheckCharPresent> ().characterAnimationTrigger);
				}
			} else {
				Destroy(character8);
			}
		}

		if (character9 != null) { 			if (GameObject.Find ("CharacterPresent_9").GetComponent<CheckCharPresent> ().isCharPresent) { 				character9.SetActive (true); 				Animator charAnimator9 = character9.GetComponent<Animator> (); 				if (charAnimator9 != null) { 					charAnimator9.SetTrigger (GameObject.Find ("CharacterPresent_9").GetComponent<CheckCharPresent> ().characterAnimationTrigger); 				} 			}  else { 				Destroy(character9); 			} 		} 
		if (character10 != null) { 			if (GameObject.Find ("CharacterPresent_10").GetComponent<CheckCharPresent> ().isCharPresent) { 				character10.SetActive (true); 				Animator charAnimator10 = character10.GetComponent<Animator> (); 				if (charAnimator10 != null) { 					charAnimator10.SetTrigger (GameObject.Find ("CharacterPresent_10").GetComponent<CheckCharPresent> ().characterAnimationTrigger); 				} 			}  else { 				Destroy(character10); 			} 		} 
		if (character11 != null) { 			if (GameObject.Find ("CharacterPresent_11").GetComponent<CheckCharPresent> ().isCharPresent) { 				character11.SetActive (true); 				Animator charAnimator11 = character11.GetComponent<Animator> (); 				if (charAnimator11 != null) { 					charAnimator11.SetTrigger (GameObject.Find ("CharacterPresent_11").GetComponent<CheckCharPresent> ().characterAnimationTrigger); 				} 			}  else { 				Destroy(character11); 			} 		} 
		if (character12 != null) { 			if (GameObject.Find ("CharacterPresent_12").GetComponent<CheckCharPresent> ().isCharPresent) { 				character12.SetActive (true); 				Animator charAnimator12 = character12.GetComponent<Animator> (); 				if (charAnimator12 != null) { 					charAnimator12.SetTrigger (GameObject.Find ("CharacterPresent_12").GetComponent<CheckCharPresent> ().characterAnimationTrigger); 				} 			}  else { 				Destroy(character12); 			} 		} 
		//Speaker Checks and Assigning Audio: 

		if (primarySpeaker != null) {
			fetchedPrimarySpeakerAudioSource = GameObject.Find ("PrimarySpeakerController").GetComponent<AudioSource> ();
			primarySpeakerIsSalsaChar = GameObject.Find ("PrimarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar;
		}

		if (secondarySpeaker != null) {
			fetchedSecondarySpeakerAudioSource = GameObject.Find ("SecondarySpeakerController").GetComponent<AudioSource> ();
			secondarySpeakerIsSalsaChar = GameObject.Find ("SecondarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar;
		}

		if (tertiarySpeaker != null) {
			fetchedTertiarySpeakerAudioSource = GameObject.Find ("TertiarySpeakerController").GetComponent<AudioSource> ();
			tertiarySpeakerIsSalsaChar = GameObject.Find ("TertiarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar;
		}

		if (quaternarySpeaker != null) {
			fetchedQuaternarySpeakerAudioSource = GameObject.Find ("QuaternarySpeakerController").GetComponent<AudioSource> ();
			quaternarySpeakerIsSalsaChar = GameObject.Find ("QuaternarySpeakerController").GetComponent<SalsaCheck> ().isSalsaChar;
		}

		if (fetchedPrimarySpeakerAudioSource != null && primarySpeakerIsSalsaChar) {
			primarySpeakerSALSA3D = primarySpeaker.GetComponent<Salsa3D> ();
			primarySpeakerSALSA3D.SetAudioClip (fetchedPrimarySpeakerAudioSource.clip);
			primarySpeakerSALSA3D.Play ();
		} else if (fetchedPrimarySpeakerAudioSource != null) {
			primarySpeakerAudioSource = primarySpeaker.GetComponent<AudioSource> ();
			primarySpeakerAudioSource.clip = fetchedPrimarySpeakerAudioSource.clip;
			primarySpeakerAudioSource.Play ();
		}

		if (fetchedSecondarySpeakerAudioSource != null && secondarySpeakerIsSalsaChar) {
			secondarySpeakerSALSA3D = secondarySpeaker.GetComponent<Salsa3D> ();
			secondarySpeakerSALSA3D.SetAudioClip (fetchedSecondarySpeakerAudioSource.clip);
			secondarySpeakerSALSA3D.Play ();
		} else if (fetchedSecondarySpeakerAudioSource != null) {
			secondarySpeakerAudioSource = secondarySpeaker.GetComponent<AudioSource> ();
			secondarySpeakerAudioSource.clip = fetchedSecondarySpeakerAudioSource.clip;
			secondarySpeakerAudioSource.Play ();
		}

		if (fetchedTertiarySpeakerAudioSource != null && tertiarySpeakerIsSalsaChar) {
			tertiarySpeakerSALSA3D = tertiarySpeaker.GetComponent<Salsa3D> ();
			tertiarySpeakerSALSA3D.SetAudioClip (fetchedTertiarySpeakerAudioSource.clip);
			tertiarySpeakerSALSA3D.Play ();
		} else if (fetchedTertiarySpeakerAudioSource != null) {
			tertiarySpeaker.GetComponent<AudioSource> ().clip = fetchedTertiarySpeakerAudioSource.clip;
			tertiarySpeakerAudioSource = tertiarySpeaker.GetComponent<AudioSource> ();
			tertiarySpeakerAudioSource.clip = fetchedTertiarySpeakerAudioSource.clip;
			tertiarySpeakerAudioSource.Play ();
		}

		if (fetchedQuaternarySpeakerAudioSource != null && quaternarySpeakerIsSalsaChar) {
			quaternarySpeakerSALSA3D = quaternarySpeaker.GetComponent<Salsa3D> ();
			quaternarySpeakerSALSA3D.SetAudioClip (fetchedQuaternarySpeakerAudioSource.clip);
			quaternarySpeakerSALSA3D.Play ();
		} else if (fetchedQuaternarySpeakerAudioSource != null) {
			quaternarySpeaker.GetComponent<AudioSource> ().clip = fetchedQuaternarySpeakerAudioSource.clip;
			quaternarySpeakerAudioSource = quaternarySpeaker.GetComponent<AudioSource> ();
			quaternarySpeakerAudioSource.clip = fetchedQuaternarySpeakerAudioSource.clip;
			quaternarySpeakerAudioSource.Play ();
		}

	}

}