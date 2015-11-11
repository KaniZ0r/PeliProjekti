using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	Animator anim;
	public float moveSpeed;
	public int enemyHealth;
	float dist;
	
	public float knockdur;
	float timer;
	bool knock;
	bool seen;

	float x;
	float y;
	
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		seen = false;
		knock = false;
	}

	void Update () {

		if (enemyHealth == 0) {
			Destroy(gameObject);
		}

		if (target) {
			dist = Vector3.Distance(transform.position, target.transform.position);
			x = target.transform.position.x - transform.position.x;
			y = target.transform.position.y - transform.position.y;

			anim.SetFloat ("X", x);
			anim.SetFloat ("Y", y);

			if (dist < 1.5) {
				seen = true;
			}
			if (seen) {
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
			}
		} else {
			target = null;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().takeDamage();
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
		}

		if (other.tag == "Weapon") {
			knock = true;
			enemyHealth--;
		}
	}
}
