using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {
	
	public Sprite face;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			FindObjectOfType<CanvasController> ().Dialog.SetActive (true);
		}
	}
	void OnTriggerStay2D (Collider2D other) {
			if (other.tag == "Player") {
			FindObjectOfType<TextScript> ().SetText ("Et voi kulkea tästä");
			FindObjectOfType<ImageScript> ().SetImage (face);
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
		}
	}
}
