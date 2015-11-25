using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossManager : MonoBehaviour {

	public Scrollbar hpBar;
	float health;
	float fullHealth;

	void Start () {
		fullHealth = FindObjectOfType<Boss_ManEaterFlower> ().health;
		health = fullHealth;
	}

	void Update () {
		health = FindObjectOfType<Boss_ManEaterFlower> ().health;
		hpBar.size = health / fullHealth;
	}

}
