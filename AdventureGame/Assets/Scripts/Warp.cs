using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform WarpTarger;
	
	IEnumerator OnTriggerEnter2D (Collider2D other) {
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		yield return StartCoroutine (sf.FadeToBlack ());

		other.gameObject.transform.position = WarpTarger.position;
		Camera.main.transform.position = WarpTarger.position;

		yield return StartCoroutine (sf.FadeToClear ());
	}
}
