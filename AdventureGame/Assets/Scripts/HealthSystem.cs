using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public GameObject hp1;
	public GameObject hp2;
	public GameObject hp3;
	public GameObject hp4;
	public GameObject hp5;

	public void Restart () {
		hp1.SetActive (true);
		hp2.SetActive (true);
		hp3.SetActive (true);
		hp4.SetActive (true);
		hp5.SetActive (true);
	}

	public void addhp() {
		switch (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().currentHP) {
		case 2:
			hp2.SetActive (true);
			break;
		case 3:
			hp3.SetActive (true);
			break;
		case 4:
			hp4.SetActive (true);
			break;
		case 5:
			hp5.SetActive (true);
			break;
		}
	}
}
