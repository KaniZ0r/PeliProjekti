using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

	GameObject coinObject;
	Vector3 target;
	float timer;
	Animator anim;
	int aliveTimer;
	public bool still;
	bool moving;
	float movingTimer;
	float movingTimer2;

	void Start () {
		coinObject = GameObject.FindGameObjectWithTag ("CoinTag");
		target = transform.position + new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
		timer = 0;
		movingTimer2 = 0;
		movingTimer = 0.2f;
		aliveTimer = 3;
		anim = GetComponent<Animator> ();
		moving = true;
	}

	void Update () {
		if (!still) {
			if (moving){
				transform.position = Vector3.MoveTowards (transform.position, target, 0.05f);
				movingTimer -= Time.deltaTime;
				if (movingTimer <= movingTimer2){
					moving = false;
				}
			}

			if (timer < aliveTimer) {
				timer += Time.deltaTime;

			} else if (timer < aliveTimer * 2) {
				timer += Time.deltaTime;
				anim.SetBool ("death", true);
			} else {
				Destroy (gameObject);
			}
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