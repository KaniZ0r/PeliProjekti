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
			hp.SetActive(true);
			yield return StartCoroutine (sf.FadeToClear ());
			bossTitle.SetActive(false);
			borders.SetActive(true);
			battle = true;
			FindObjectOfType<Boss_ManEaterFlower>().setStart();
		}
	}

}
