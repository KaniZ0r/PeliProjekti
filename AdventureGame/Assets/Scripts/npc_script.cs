using UnityEngine;
using System.Collections;

public class npc_script : MonoBehaviour {

	public GUIStyle customGuiStyle;
	public Sprite oldmanHead;
	string text;
	string name1;

	public GameObject textbox;

	Vector3 screenpos;

	void OnTriggerStay2D(Collider2D Other){
		if (Other.tag == "Player") {
			textbox.SetActive(true);
			text = "Haluan vain kertoa, että Alppu2 on vitun homoneekerin mätäpaska!!½";
			FindObjectOfType<TextScript>().SetText(text);
			FindObjectOfType<ImageScript>().SetImage(oldmanHead);
		}

	}
	void OnTriggerExit2D(Collider2D Other){
		if (Other.tag == "Player") {
			textbox.SetActive(false);
		}
	}
}
