using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public GameObject player;
	public GameObject death;
	public Transform checkpoint;
	public GameObject bossManager;
	ScreenFader sf;
	bool deathBool;
	bool aliveBool;
	public AudioSource mainSong;
	public AudioSource bossSong;


	void Start(){
		sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
		deathBool = false;
		aliveBool = true;
		var sources = GetComponents<AudioSource> ();
		mainSong = sources [0];
		bossSong = sources [1];
	}
	// Update is called once per frame
	void Update () {
	
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, 0.1f) + new Vector3 (0, 0, -10);
		}
		if (player.GetComponent<PlayerController>().currentHP <= 0) {
			if (bossManager.activeSelf){
				bossManager.GetComponent<BossManager>().playerDie();
			}
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
		player.GetComponent<Animator> ().SetBool ("die", false);
		aliveBool = true;
		target = player.transform;
		target.transform.position = checkpoint.transform.position;
		yield return StartCoroutine(sf.FadeToBlack ());
		target.transform.position = checkpoint.transform.position;
		death.SetActive (false);
		yield return StartCoroutine(sf.FadeToClear ());
		target.transform.position = checkpoint.transform.position;
		FindObjectOfType<HealthSystem> ().Restart ();
	}
}