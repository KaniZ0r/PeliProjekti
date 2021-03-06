﻿using UnityEngine;
using System.Collections;

public class Boss_ManEaterFlower : MonoBehaviour {

	Transform target;
	public GameObject projectile;
	Animator anim;
	float x;
	float y;
	public int health;
	public int startHealth;
	int fullHealth;
	bool start;
	AudioSource attack;
	AudioSource hurt;

	void Start () {
		fullHealth = startHealth;
		health = fullHealth;
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag ("Player").transform;
		start = false;
		var sources = GetComponents<AudioSource> ();
		attack = sources [0];
		hurt = sources [1];
	}
	
	// Update is called once per frame
	void Update () {
		x = target.transform.position.x - transform.position.x;
		y = target.transform.position.y - transform.position.y;
		
		anim.SetFloat ("X", x);
		anim.SetFloat ("Y", y);		

		if (health <= 0) {
			FindObjectOfType<BossManager>().endBattle1();
			Destroy(gameObject);
		}

		if (start) {
			StartCoroutine (shootProjectile (4f));
			start = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Weapon") {
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
			health--;
			hurt.Play();
		}
	}

	public void setStart (){
		start = true;
	}

	public void resetHP(){
		health = fullHealth;
	}

	IEnumerator shootProjectile (float seconds){
		while (true) {
			if (health > fullHealth/2){
				yield return new WaitForSeconds (1.7f);
				GameObject p1 = (GameObject)Instantiate (projectile, this.transform.position, target.transform.rotation);
				p1.GetComponent<ProjectileController>().suunta = (transform.position - target.transform.position).normalized;
				attack.Play();
				yield return new WaitForSeconds (0.5f);
				GameObject p2 = (GameObject)Instantiate (projectile, this.transform.position, target.transform.rotation);
				p2.GetComponent<ProjectileController>().suunta = (transform.position - target.transform.position).normalized;
				attack.Play();
				yield return new WaitForSeconds (0.5f);
				GameObject p3 = (GameObject) Instantiate (projectile, this.transform.position, target.transform.rotation);
				p3.GetComponent<ProjectileController>().suunta = (transform.position - target.transform.position).normalized;
				attack.Play();
			} else {
				yield return new WaitForSeconds(2.0f);
				GameObject p1 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p2 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p3 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p4 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				p1.GetComponent<ProjectileController>().suunta = new Vector3(0, 1, 0);
				p2.GetComponent<ProjectileController>().suunta = new Vector3(0, -1, 0);
				p3.GetComponent<ProjectileController>().suunta = new Vector3(1, 0, 0);
				p4.GetComponent<ProjectileController>().suunta = new Vector3(-1, 0, 0);
				attack.Play();
				yield return new WaitForSeconds(0.5f);
				GameObject p5 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p6 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p7 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p8 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				p5.GetComponent<ProjectileController>().suunta = new Vector3(1, 1, 0);
				p6.GetComponent<ProjectileController>().suunta = new Vector3(1, -1, 0);
				p7.GetComponent<ProjectileController>().suunta = new Vector3(-1, 1, 0);
				p8.GetComponent<ProjectileController>().suunta = new Vector3(-1, -1, 0);
				attack.Play();
				yield return new WaitForSeconds(0.5f);
				GameObject p9 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p10 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p11 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p12 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p13 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p14 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p15 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				GameObject p16 = (GameObject)Instantiate(projectile, this.transform.position, target.transform.rotation);
				p9.GetComponent<ProjectileController>().suunta = new Vector3(0, 1, 0);
				p10.GetComponent<ProjectileController>().suunta = new Vector3(0, -1, 0);
				p11.GetComponent<ProjectileController>().suunta = new Vector3(1, 0, 0);
				p12.GetComponent<ProjectileController>().suunta = new Vector3(-1, 0, 0);
				p13.GetComponent<ProjectileController>().suunta = new Vector3(1, 1, 0);
				p14.GetComponent<ProjectileController>().suunta = new Vector3(1, -1, 0);
				p15.GetComponent<ProjectileController>().suunta = new Vector3(-1, 1, 0);
				p16.GetComponent<ProjectileController>().suunta = new Vector3(-1, -1, 0);
				attack.Play();
			}
		}
	}
}
