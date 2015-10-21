using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Transform target;
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
			} else {
				timer = 0;
				knock = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
				//Destroy(other.gameObject);
			Debug.Log("osuma!");
		}
		if (other.tag == "Weapon") {
			//	knockbackin suunta
			knock = true;

			/*if (enemyHealth < 1) {
				Destroy (gameObject);
			}
			else {
				enemyHealth--;
			}*/
		}
	}
}
