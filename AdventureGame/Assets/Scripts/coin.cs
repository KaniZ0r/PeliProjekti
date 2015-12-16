using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

	GameObject coinObject;
	Vector3 target;
	float timer;
	Animator anim;
	int aliveTimer;

	void Start () {
		coinObject = GameObject.FindGameObjectWithTag ("CoinTag");
		target = transform.position + new Vector3 (Random.Range (-1, 1), Random.Range (-1, 1));
		timer = 0;
		aliveTimer = 2;
		anim = GetComponent<Animator> ();
	}

	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, 0.05f);

		if (timer < aliveTimer) {
			timer += Time.deltaTime;

		} else if (timer < aliveTimer * 2) {
			timer += Time.deltaTime;
			anim.SetBool ("death", true);
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().addCoins();
			int coins = other.GetComponent<PlayerController>().coins;
			coinObject.GetComponentInChildren<TextScript>().SetText(coins.ToString());
			Destroy(gameObject);
		}
	}
}
