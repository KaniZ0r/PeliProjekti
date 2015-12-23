using UnityEngine;
using System.Collections;

public class EnemyMoveRandom : MonoBehaviour {

	public Transform target;
	Animator anim;
	public int enemyHealth;
	public float moveSpeed;
	AudioSource hurt;
	AudioSource move;
	
	public GameObject coin;
	public float knockdur;
	float timer;
	bool knock;
	
	float x;
	float y;

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
		var sources = GetComponents<AudioSource> ();
		hurt = sources [0];
		move = sources [1];
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		knock = false;
		moving = true;
		moveTime = 0;
		waitTime = 0;
		moveSound = true;
		moveTimeCounter = Random.Range (movingTime * 0.20f, movingTime * 0.35f);
		waitTimeCounter = Random.Range (movingTime * 1f, movingTime * 1.5f);
		moveDirection = new Vector3 (Random.Range (-1f, 1f)  * moveSpeed, Random.Range (-1f, 1f) * moveSpeed);
	}
	
	void Update () {
		
		if (enemyHealth == 0) {
			for (int i = 0; i < Random.Range (2, 5); i++){
				Instantiate (coin, transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		if (!knock) {
			if (moving){
				if (moveSound)
				{
					move.Play();
					moveSound = false;
				}
				rb2d.velocity = moveDirection;
				moveTime += Time.deltaTime;
				if (moveTime >= moveTimeCounter){
					waitTimeCounter = Random.Range (movingTime * 0.75f, movingTime * 1.25f);
					waitTime = 0;
					moving = false;
				}
			} else {
				rb2d.velocity = Vector2.zero;
				waitTime += Time.deltaTime;
				if (waitTime >= waitTimeCounter)
				{
					moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed);
					moveTimeCounter = Random.Range (movingTime * 0.75f, movingTime * 1.25f);
					moveTime = 0;
					moving = true;
					moveSound = true;
				}
			}

		} else {
			if (knockdur > timer) {
				rb2d.velocity = -(target.transform.position - transform.position).normalized * Time.deltaTime * 200;
				timer += Time.deltaTime;
				anim.SetTrigger ("hurt");
			} else {
				timer = 0;
				moveTimeCounter = Random.Range (movingTime * 0.75f, movingTime * 1.25f);
				moveTime = 0;
				moving = true;
				moveSound = true;
				knock = false;
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().takeDamage();
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
		}
		
		if (other.tag == "Weapon") {
			hurt.Play();
			knock = true;
			enemyHealth--;
		}
	}
}
