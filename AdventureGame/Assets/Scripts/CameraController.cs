using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	
	// Update is called once per frame
	void Update () {
	
		if (target) {
			transform.position = Vector3.Lerp (transform.position, target.position, 0.1f) + new Vector3 (0, 0, -10);
		}
	}
}
