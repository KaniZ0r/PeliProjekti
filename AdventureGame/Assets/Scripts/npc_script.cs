using UnityEngine;
using System.Collections;

public class npc_script : MonoBehaviour {

	public GUIStyle customGuiStyle;
	public Sprite oldmanHead;
	bool readed = false;
	public int page = 0;
	public GameObject textbox;
	public TextAsset textfile1;
	public TextAsset textfile2;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (page == 1) {
			FindObjectOfType<TextScript> ().SetText (textfile1.text);
			FindObjectOfType<ImageScript> ().SetImage (oldmanHead);
		} else {
			FindObjectOfType<TextScript> ().SetText (textfile2.text);
			FindObjectOfType<ImageScript> ().SetImage (oldmanHead);
		}
	}

	void OnTriggerStay2D(Collider2D Other){
		if (Other.tag == "Player") {
			page = 1;
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
			page = 0;
		}
	}
}
