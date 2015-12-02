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
	}

	void Update () {
		if (battle) {
			health = FindObjectOfType<Boss_ManEaterFlower> ().health;
			hpBar.size = health / fullHealth;
			if (health == 0){
				StartCoroutine(endBattle());
			}
		}
	}

	IEnumerator OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
			FindObjectOfType<PlayerController> ().Freeze ();
			bossTitle.SetActive(true);
			yield return StartCoroutine (sf.FadeToBlack ());
			boss.SetActive(true);
			other.gameObject.transform.position = warpTarget.position;
			FindObjectOfType<CameraController>().target = GameObject.FindWithTag ("Boss").transform;
			Camera.main.orthographicSize = 2.5f;
			hp.SetActive(true);
			yield return StartCoroutine (sf.FadeToClear ());
			FindObjectOfType<Boss_ManEaterFlower>().setStart();
			fullHealth = FindObjectOfType<Boss_ManEaterFlower> ().health;
			bossTitle.SetActive(false);
			borders.SetActive(true);
			battle = true;
		}
	}

	IEnumerator endBattle () {
		FindObjectOfType<CameraController> ().target = GameObject.FindWithTag ("Player").transform;
		hp.SetActive (false);
		Destroy (gameObject);
		Camera.main.orthographicSize = 2f;
		yield return new WaitForFixedUpdate();
	}

}
