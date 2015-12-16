using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public GameObject introbg;
	public Sprite head_player;
	public GameObject textbox;

	// Use this for initialization
	void Start () {
		introbg.SetActive (true);
		FindObjectOfType<PlayerController> ().Freeze ();
		StartCoroutine (IntroGo());
	}

	IEnumerator IntroGo () {
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
		introbg.GetComponentInChildren<TextScript> ().SetText ("World is a dire place... \nIt became very clear to our hero at young age...");
		yield return new WaitForSeconds(3f);
		introbg.GetComponentInChildren<TextScript> ().SetText ("His parents lives were taken by wicked man... \nThis wayfarer of misery left our boy alive...");
		yield return new WaitForSeconds(3f);
		introbg.GetComponentInChildren<TextScript> ().SetText ("Fulfill your destiny and seek revenge!");
		yield return new WaitForSeconds(3f);
		yield return StartCoroutine(sf.FadeToBlack());
		introbg.SetActive (false);
		yield return StartCoroutine (sf.FadeToClear());
		textbox.SetActive (true);
		textbox.GetComponentInChildren<TextScript> ().SetText ("Im gonna kill that motherfucker!?!?!?");
		textbox.GetComponentInChildren<ImageScript> ().SetImage (head_player);
		yield return new WaitForSeconds (2f);
		textbox.SetActive (false);
		FindObjectOfType<PlayerController> ().UnFreeze ();
		Destroy (gameObject);
	}
}
