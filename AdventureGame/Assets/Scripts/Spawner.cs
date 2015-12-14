using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public Transform spawn1;
	public Transform spawn2;
	public Transform spawn3;
	public Transform spawn4;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Instantiate(spawnObject, spawn1.position, Quaternion.identity);
			Instantiate(spawnObject, spawn2.position, Quaternion.identity);
			Instantiate(spawnObject, spawn3.position, Quaternion.identity);
			Instantiate(spawnObject, spawn4.position, Quaternion.identity);
			Destroy(this);
		}
	}
}
