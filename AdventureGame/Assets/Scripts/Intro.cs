using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	public GameObject introbg;
	public GameObject introtext;

	// Use this for initialization
	void Start () {
		introbg.SetActive (true);
		StartCoroutine (IntroGo());
		FindObjectOfType<PlayerController> ().Freeze ();
	}

	IEnumerator IntroGo () {
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
		introtext.GetComponent<TextScript> ().SetText ("World is a dire place...");
		yield return new WaitForSeconds(3f);
		introtext.GetComponent<TextScript> ().SetText ("It became very clear to our hero at young age...");
		yield return new WaitForSeconds(3f);
		introtext.GetComponent<TextScript> ().SetText ("His parents lives were taken by wicked man...");
		yield return new WaitForSeconds(3f);
		introtext.GetComponent<TextScript> ().SetText ("This wayfarer of misery left our boy alive...");
		yield return new WaitForSeconds(3f);
		introtext.GetComponent<TextScript> ().SetText ("But was it a mistake?");
		yield return new WaitForSeconds(3f);
		yield return StartCoroutine(sf.FadeToBlack());
		introbg.SetActive (false);
		yield return StartCoroutine (sf.FadeToClear());
		FindObjectOfType<PlayerController> ().UnFreeze ();
		Destroy (gameObject);
	}
}
