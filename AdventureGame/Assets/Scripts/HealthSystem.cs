using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

	public GameObject hp1;
	public GameObject hp2;
	public GameObject hp3;

	public void Restart () {
		hp1.SetActive (true);
		hp2.SetActive (true);
		hp3.SetActive (true);
	}
}
