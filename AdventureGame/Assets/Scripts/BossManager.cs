using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossManager : MonoBehaviour {

	public GameObject boss;
	public Transform warpTarget;
	public GameObject borders;
	public GameObject hp;
	public Scrollbar hpBar;
	public GameObject bossTitle;
	float health;
	float fullHealth;
	bool battle;

	void Start () {
		battle = false;
	}

	void Update () {
		if (battle) {
			health = FindObjectOfType<Boss_ManEaterFlower> ().health;
			hpBar.size = health / fullHealth;
		}
	}

	public void endBattle1 () {
		StartCoroutine (endBattle ());
	}

	IEnumerator OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			FindObjectOfType<CameraController>().mainSong.Stop();
			FindObjectOfType<CameraController>().bossSong.Play();
			ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
			FindObjectOfType<PlayerController> ().Freeze ();
			bossTitle.SetActive(true);
			yield return StartCoroutine (sf.FadeToBlack ());
			boss.SetActive(true);
			other.gameObject.transform.position = warpTarget.position;
			FindObjectOfType<CameraController>().target = GameObject.FindWithTag ("Boss").transform;
			Camera.main.orthographicSize = 2.5f;
			boss.GetComponent<Boss_ManEaterFlower>().resetHP();
			hp.SetActive(true);
			yield return StartCoroutine (sf.FadeToClear ());
			FindObjectOfType<Boss_ManEaterFlower>().setStart();
			fullHealth = FindObjectOfType<Boss_ManEaterFlower> ().startHealth;
			bossTitle.SetActive(false);
			borders.SetActive(true);
			battle = true;
		}
	}

	IEnumerator endBattle () {
		FindObjectOfType<CameraController>().bossSong.Stop();
		FindObjectOfType<CameraController>().mainSong.Play();
		battle = false;
		FindObjectOfType<QuestManager> ().nextPhase ();
		FindObjectOfType<CameraController> ().target = GameObject.FindWithTag ("Player").transform;
		hp.SetActive (false);
		Destroy (gameObject);
		Camera.main.orthographicSize = 2f;
		yield return new WaitForFixedUpdate();
	}

	public void playerDie () {
		FindObjectOfType<CameraController>().bossSong.Stop();
		FindObjectOfType<CameraController>().mainSong.Play();
		boss.SetActive (false);
		borders.SetActive (false);
		hp.SetActive (false);
		Camera.main.orthographicSize = 2f;
	}
}
