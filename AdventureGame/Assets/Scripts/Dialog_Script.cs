using UnityEngine;
using System.Collections;

public class Dialog_Script : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			gameObject.SetActive(false);
		}
	}
}
