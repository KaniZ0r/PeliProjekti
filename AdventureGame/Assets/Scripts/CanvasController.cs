using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {
		
	public GameObject Dialog;
	float timer;
	float timer1;
	bool itsActive;

	void Start () {
		timer = 2;
		itsActive = false;
	}


	void Update () {
		if (Dialog) {
			itsActive = true;
		}
		if (itsActive) {
			timer1 = 0;
			if (timer1 < timer) {
				timer += Time.deltaTime;
			} else {
				Dialog.SetActive(false);
				itsActive = false;
			}	
		}
	}
}