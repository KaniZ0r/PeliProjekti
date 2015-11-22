using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	public float speed;
	Rigidbody2D rb2d;
	Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
		anim.SetBool("hit", true);
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().takeDamage();
		}
		Destroy (gameObject);
	}
}