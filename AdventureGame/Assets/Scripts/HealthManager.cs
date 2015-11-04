using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	GameObject playerHP;
	public int heart;


	// Use this for initialization
	void Start () {
		playerHP = GameObject.FindWithTag ("Player");
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHP.GetComponent<PlayerController>().currentHP < heart) {
			gameObject.SetActive(false);
		}
	}
}
