using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public GameObject player;
	public GameObject death;
	public Transform checkpoint;
	ScreenFader sf;
	bool deathBool;
	bool aliveBool;

	void Start(){
		sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
		deathBool = false;
		aliveBool = true;
	}
	// Update is called once per frame
	void Update () {
	
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, 0.1f) + new Vector3 (0, 0, -10);
		}

		if (player.GetComponent<PlayerController>().currentHP <= 0) {
			if (aliveBool){
				deathBool = true;
				aliveBool = false;
			}
			if (deathBool){
				StartCoroutine(Death ());
			}
			if (Input.GetKey (KeyCode.Space)){
				aliveBool = false;
				if (!aliveBool){
					StartCoroutine(Alive ());
				}
			}
		}
	}

	IEnumerator Death(){
		deathBool = false;
		yield return StartCoroutine(sf.FadeToBlack ());
		death.SetActive (true);
		yield return StartCoroutine(sf.FadeToClear ());

	}

	IEnumerator Alive(){
		player.GetComponent<PlayerController> ().currentHP = player.GetComponent<PlayerController> ().maxHP;
		aliveBool = true;
		target.transform.position = checkpoint.transform.position;
		yield return StartCoroutine(sf.FadeToBlack ());
		death.SetActive (false);
		yield return StartCoroutine(sf.FadeToClear ());
		FindObjectOfType<HealthSystem> ().Restart ();
	}
}
