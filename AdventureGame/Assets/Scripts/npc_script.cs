using UnityEngine;
using System.Collections;

public class npc_script : MonoBehaviour {

	public GUIStyle customGuiStyle;
	public Sprite oldmanHead;
	bool readed = false;
	public int page = 1;
	public GameObject textbox;
	public TextAsset textfile1;
	public TextAsset textfile2;
	Animator anim;

	void Update () {

		anim = GetComponent<Animator> ();

		FindObjectOfType<ImageScript> ().SetImage (oldmanHead);
		if (page == 1) {
			FindObjectOfType<TextScript> ().SetText (textfile1.text);
		} else {
			FindObjectOfType<TextScript> ().SetText (textfile2.text);
		}
	}

	void OnTriggerStay2D(Collider2D Other){
		if (Other.tag == "Player") {
			if (readed == false) {
				FindObjectOfType<PlayerController> ().Freeze ();
				textbox.SetActive (true);
			}
			if (Input.GetKeyDown (KeyCode.Space) && readed == true) {
				FindObjectOfType<PlayerController> ().UnFreeze ();
				textbox.SetActive (false);
				anim.SetBool("Died", true);
			}
			if (Input.GetKeyDown (KeyCode.Space) && page == 1) {
				page = 2;
				readed = true;
			}

		}
	}

	void OnTriggerExit2D(Collider2D Other) {
		if (Other.tag == "Player") {
			readed = false;
			page = 1;
		}
	}
}
