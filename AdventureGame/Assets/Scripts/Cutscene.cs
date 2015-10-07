using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour {
	
	int phase = 0;
	public Transform newtarget;
	Transform targetPlayer;
	public TextAsset textfile1;

	void Awake ()
	{
		InvokeRepeating ("Scene", 0f, 3f);
	}
	
	void Scene ()
	{	
		phase++;
		switch (phase) {
		case 1:
			targetPlayer = FindObjectOfType<CameraController>().target;
			FindObjectOfType<CameraController>().target = GameObject.FindWithTag ("NPC").transform;
			FindObjectOfType<npc_script>().textbox.SetActive(true);
			FindObjectOfType<TextScript>().SetText ("Muna");
			FindObjectOfType<ImageScript>().SetImage(FindObjectOfType<npc_script>().oldmanHead);
			break;
		case 2:
			FindObjectOfType<npc_script>().textbox.SetActive(false);
			FindObjectOfType<CameraController>().target = targetPlayer;
			FindObjectOfType<PlayerController>().UnFreeze();
			Destroy(gameObject);
			break;
		}

	}
}
