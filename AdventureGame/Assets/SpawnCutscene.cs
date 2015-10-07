using UnityEngine;
using System.Collections;

public class SpawnCutscene : MonoBehaviour {

	public GameObject cutscene;

	void OnTriggerEnter2D (Collider2D Other) {
		if (Other.tag == "Player") {
			FindObjectOfType<PlayerController>().Freeze();
			Instantiate(cutscene, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}


	}
}
