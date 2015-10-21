using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	public Animator anim;
	public float moveSpeed;
	public int enemyHealth;

	public float knockback;
	public bool knockdirection1;
	public bool knockdirection2;
	public float knockdur;
	public float timer;

	public Rigidbody2D rb2d;

	public float x;
	public float y;
	
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
	}

	void Update () {

		x = target.transform.position.x - transform.position.x;
		y = target.transform.position.y - transform.position.y;

		anim.SetFloat ("X", x);
		anim.SetFloat ("Y", y);

		transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;

		if (target.transform.position.x > transform.position.x) {
			knockdirection1 = true;
		} else {
			knockdirection1 = false;
		}
		if (target.transform.position.y > transform.position.y) {
			knockdirection2 = true;
		} else {
			knockdirection2 = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
				//Destroy(other.gameObject);
			Debug.Log("osuma!");
		}
		if (other.tag == "Weapon") {
			//	knockbackin suunta
			StartCoroutine(Knockback());

			if (enemyHealth < 1) {
				Destroy (gameObject);
			}
			else {
				enemyHealth--;
			}
		}
	}

	public IEnumerator Knockback() {
		knockdur = 10;
		timer = 0;
		while (knockdur > timer) {
			timer += Time.deltaTime;

			if (knockdirection1 && knockdirection2) {
				rb2d.velocity = new Vector2 (-knockback, -knockback);
			}
			else if (!knockdirection1 && knockdirection2){
				rb2d.velocity = new Vector2 (knockback, -knockback);
			}
			else if (knockdirection1 && !knockdirection2) {
				rb2d.velocity = new Vector2 (-knockback, knockback);
			}
			else if (!knockdirection1 && !knockdirection2) {
				rb2d.velocity = new Vector2 (knockback, knockback);
			}
		}
		yield return 0;
	}
}
