using UnityEngine;
using System.Collections;

public class Nami_follow : MonoBehaviour {

	Animator anim;
	public Transform target;
	public float moveSpeed;
	public bool follow;
	float x, y;
	public float dist;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Update() {
		if (target && follow) {
			x = target.transform.position.x - transform.position.x + 0.2f;
			y = target.transform.position.y - transform.position.y;
			dist = Vector3.Distance (transform.position, target.transform.position);
		
			anim.SetFloat ("X", x);
			anim.SetFloat ("Y", y);

			if (dist > 0.6f) {
				anim.SetBool ("follow", true);
				transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
			} else if (dist <= 0.6f && dist >= 0.55f) {
				anim.SetBool ("follow", false);
			} else if (dist < 0.55f) {
				anim.SetBool("follow", true);
				transform.position -= (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<Quest_npc1>().resetText();
			anim.SetBool("follow", true);
			follow = true;
		}
	}
}

