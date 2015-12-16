using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Camera.main.GetComponent<CameraController>().checkpoint = this.transform;
		}
	}
}
