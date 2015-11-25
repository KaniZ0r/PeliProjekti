using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public float speed;
	Rigidbody2D rb2d;
	Animator anim;
	Vector3 suunta;
	public Transform target;

	float kulmakerroin;
	float radiaanit;
	float asteet;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag ("Player").transform;
		suunta = (transform.position - target.transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = -suunta * speed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		anim.SetBool("hit", true);
		kulmakerroin = (other.transform.position.y - transform.position.y) / (other.transform.position.x - transform.position.x);
		radiaanit = Mathf.Atan (kulmakerroin);
		asteet = Mathf.Rad2Deg * radiaanit;

		if (other.transform.position.x > transform.position.x) {
			transform.eulerAngles = new Vector3 (0, 0, asteet);
		} else {
			transform.eulerAngles = new Vector3 (0, 0, asteet + 180);
		}

		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().takeDamage();
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
		}
		Destroy (gameObject, 0.4f);
	}
}