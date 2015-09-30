using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	Animator anim;
	bool isFading;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public IEnumerator FadeToClear() {
		isFading = true;
		anim.SetTrigger ("FadeIn");
		anim.SetBool ("FadeOut", false);

		while (isFading)
			yield return null;
	}

	public IEnumerator FadeToBlack() {
		isFading = true;
		anim.SetTrigger ("FadeOut");
		anim.SetBool ("FadeIn", false);

		while (isFading)
			yield return null;
	}

	void AnimationComplete(){
		isFading = false;
		FindObjectOfType<PlayerController> ().UnFreeze ();
	}
}
