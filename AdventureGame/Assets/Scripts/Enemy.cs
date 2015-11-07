using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	Animator anim;
	public float moveSpeed;
	public int enemyHealth;
	
	public float knockdur;
	float timer;
	bool knock;

	float x;
	float y;
	
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();

		knock = false;
	}

	void Update () {

		if (enemyHealth == 0) {
			Destroy(gameObject);
		}

		if (target) {

			x = target.transform.position.x - transform.position.x;
			y = target.transform.position.y - transform.position.y;

			anim.SetFloat ("X", x);
			anim.SetFloat ("Y", y);

			if (!knock) {
				transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
			} else {
				if (knockdur > timer) {
					transform.position -= (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime * 8;
					timer += Time.deltaTime;
					anim.SetTrigger("hurt");
				} else {
					timer = 0;
					knock = false;
				}
			}
		} else {
			target = null;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().takeDamage();
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
			knock = true;
		}

		if (other.tag == "Weapon") {
			knock = true;
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
			enemyHealth--;
		}
	}
}
