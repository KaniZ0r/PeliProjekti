using UnityEngine;
using System.Collections;

public class Boss_ManEaterFlower : MonoBehaviour {

	public Transform target;
	public GameObject projectile;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Instantiate (projectile, this.transform.position, this.transform.rotation);

	}
}
