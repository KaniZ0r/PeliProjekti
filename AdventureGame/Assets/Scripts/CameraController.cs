using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public GameObject player;
	public GameObject death;
	public Transform checkpoint;
	ScreenFader sf;

	void Start(){
		sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
	}
	// Update is called once per frame
	void Update () {
	
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, 0.1f) + new Vector3 (0, 0, -10);
		}

		if (!player) {
			StartCoroutine(Death ());
			if (Input.GetKey (KeyCode.Space)){
				StartCoroutine(Alive ());
			}
		}
	}

	IEnumerator Death(){
		death.SetActive (true);
		yield return new WaitForSeconds (0);
	}

	IEnumerator Alive(){
		death.SetActive (false);
		player.GetComponent<PlayerController> ().currentHP = player.GetComponent<PlayerController> ().maxHP;
		player.SetActive (true);
		yield return new WaitForSeconds (0);
	}
}
