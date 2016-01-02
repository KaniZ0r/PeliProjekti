using UnityEngine;
using System.Collections;

public class EnemyMoveRandom : MonoBehaviour {

	public Transform target;
	Animator anim;
	public int enemyHealth;
	public float moveSpeed;
	AudioSource hurt;
	AudioSource move;
	public float dist;
	bool seen;
	float x;
	float y;

	public GameObject heart;
	public GameObject coin;
	public float knockdur;
	float timer;
	bool knock;
	public float movingTime;
	float moveTime;
	float waitTime;
	float moveTimeCounter;
	float waitTimeCounter;
	bool moving;
	bool moveSound;

	Rigidbody2D rb2d;
	Vector3 moveDirection;

	void Start () {
		//var sources = GetComponents<AudioSource> ();
		//hurt = sources [0];
		//move = sources [1];
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		knock = false;
		moving = true;
		moveTime = 0;
		waitTime = 0;
		seen = false;
		//moveSound = true;
		moveTimeCounter = Random.Range (movingTime * 0.20f, movingTime * 0.35f);
		waitTimeCounter = Random.Range (movingTime * 1f, movingTime * 1.5f);
		x = Random.Range (-1f, 1f);
		y = Random.Range (-1f, 1f);
		moveDirection = new Vector3 (x / 2  * moveSpeed, y / 2 * moveSpeed);
	}
	
	void Update () {

		if (target) {
			dist = Vector3.Distance (transform.position, target.transform.position);
			
			anim.SetFloat ("X", x);
			anim.SetFloat ("Y", y);
			
			if (dist < 1.5f) {
				seen = true;
				x = target.transform.position.x - transform.position.x;
				y = target.transform.position.y - transform.position.y;
			} else {
				seen = false;
			}

			if (seen) {
				moveDirection = (target.transform.position - transform.position).normalized * 3 / 4;
			}

			// --- aggro ---
			/**
			if (seen) {
				if (!knock) {
					rb2d.velocity = Vector2.zero;
					transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
				} else {
					if (knockdur > timer) {
						transform.position -= (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime * 6;
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
		**/

			// --- random liikkuminen ---
			if (moving) {
				/*if (moveSound)
				{
					move.Play();
					moveSound = false;
				}*/
				if (!knock) {
					rb2d.velocity = moveDirection;
					moveTime += Time.deltaTime;
				} else {
					if (knockdur > timer) {
						transform.position -= (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime * 6;
						timer += Time.deltaTime;
						anim.SetTrigger("hurt");
					} else {
						timer = 0;
						moveTime = moveTimeCounter;
						knock = false;
					}
				}
				if (moveTime >= moveTimeCounter) {
					waitTimeCounter = Random.Range (movingTime * 0.75f, movingTime * 1.25f);
					waitTime = 0;
					moving = false;
				}
			} else {
				if (!knock) {
					rb2d.velocity = Vector2.zero;
					waitTime += Time.deltaTime;
				} else {
					if (knockdur > timer) {
						transform.position -= (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime * 6;
						timer += Time.deltaTime;
						anim.SetTrigger("hurt");
					} else {
						timer = 0;
						waitTime = waitTimeCounter;
						knock = false;
					}
				}
				if (waitTime >= waitTimeCounter) {
					x = Random.Range (-1f, 1f);
					y = Random.Range (-1f, 1f);
					moveDirection = new Vector3 (x / 2  * moveSpeed, y / 2 * moveSpeed);
					moveTimeCounter = Random.Range (movingTime * 0.75f, movingTime * 1.25f);
					moveTime = 0;
					moving = true;
					moveSound = true;
				}
			}

			if (enemyHealth == 0) {
				if (Random.Range(0, 6) > 4) {
					Instantiate (heart, transform.position, Quaternion.identity);
				}
				for (int i = 0; i < Random.Range (2, 4); i++) {
					Instantiate (coin, transform.position, Quaternion.identity);
				}
				Destroy (gameObject);
			}
		}
	}

	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().takeDamage();
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
		}
		
		if (other.tag == "Weapon") {
			//hurt.Play();
			knock = true;
			enemyHealth--;
		}
	}
}
