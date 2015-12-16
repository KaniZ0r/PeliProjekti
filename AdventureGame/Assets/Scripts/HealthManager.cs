using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	GameObject playerHP;
	public int heart;


	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentHP < heart) {
			gameObject.SetActive(false);
		}
	}
}
