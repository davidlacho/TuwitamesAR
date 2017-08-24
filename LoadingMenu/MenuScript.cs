using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public Canvas optionsMenu;
	public Button startText;
	public Button optionsText;
	public Canvas startMenu;

	void Start () {
		optionsMenu = optionsMenu.GetComponent<Canvas>();
		startText = startText.GetComponent<Button>();
		optionsText = optionsText.GetComponent<Button>();
		optionsMenu.enabled = false;
	}

	public void OptionsPress () {
		optionsMenu.enabled = true;
		startText.enabled = false;
		optionsText.enabled = false;
	}

	public void NoPress() {
		optionsMenu.enabled = false;
		startText.enabled = true;
		optionsText.enabled = true;
	}

	public void Startlevel () {
		StartCoroutine(StartApp());
	}

	public void ExitGame () {
		Application.Quit(); 
	}

	public IEnumerator StartApp () {
		AsyncOperation loading = SceneManager.LoadSceneAsync ("LoadingScene", LoadSceneMode.Single);
		while (!loading.isDone) {
			yield return null;
		}
	}

}
