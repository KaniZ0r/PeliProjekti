using UnityEngine;
using System.Collections;

public class XP_Point : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<PlayerController> ().AddXP ();
			Destroy (gameObject);
		}
	}

}
