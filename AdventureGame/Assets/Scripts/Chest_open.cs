using UnityEngine;
using System.Collections;

public class Chest_open : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Weapon") {
			anim.SetBool("open", true);
		}
	}
}
