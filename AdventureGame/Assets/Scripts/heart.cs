using UnityEngine;
using System.Collections;

public class heart : MonoBehaviour {

	public bool still;
	bool moving;
	float movingTimer;
	float movingTimer2;
	float timer;
	float aliveTimer;
	Animator anim;
	Vector3 target;

	void Start () {
		target = transform.position + new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
		timer = 0;
		movingTimer2 = 0;
		movingTimer = 0.2f;
		aliveTimer = 3;
		anim = GetComponent<Animator> ();
		moving = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (other.GetComponent<PlayerController>().currentHP != 5) {
				other.GetComponent<PlayerController> ().addHP();
				FindObjectOfType<HealthSystem>().addhp();
				Destroy(gameObject);
			}
		}
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
}
