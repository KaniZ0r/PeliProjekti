using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	public Animator anim;
	public float moveSpeed;

	float x;
	float y;


	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		x = target.transform.position.x - transform.position.x;
		y = target.transform.position.y - transform.position.y;

		anim.SetFloat ("X", x);
		anim.SetFloat ("Y", y);

		transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Destroy(other.gameObject);
		}
		if (other.tag == "Weapon") {
			Destroy (gameObject);
		}
	}
}
