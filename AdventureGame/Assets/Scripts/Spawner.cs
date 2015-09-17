using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public float spawnRate;
	
	void Awake ()
	{
		spawnRate = Random.Range (0.5f, 3f);
		InvokeRepeating ("Spawn", 0f, spawnRate);
	}

	void Spawn ()
	{
		Instantiate (spawnObject, transform.position, Quaternion.identity);
	}
}
