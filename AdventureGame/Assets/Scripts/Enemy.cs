using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform target;
	public float moveSpeed;


	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (target.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Destroy(other.gameObject);
		}
		if (other.tag == "Weapon") {
			Destroy (gameObject);
		}
	}
}
