using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {
	
	public Sprite face;
	Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void OnTriggerStay2D (Collider2D other) {
			if (other.tag == "Player") {
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
			anim.SetTrigger("hit");
		}
	}
}
