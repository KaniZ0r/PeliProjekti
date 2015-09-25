using UnityEngine;
using System.Collections;

public class npc_script : MonoBehaviour {

	public GUIStyle customGuiStyle;
	public Texture2D oldmanHead;
	bool showGui;

	// Use this for initialization
	void Start () {
		showGui = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D Other){
		if (Other.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.Space)) {
				showGui = true;

			}
		}

	}
	void OnTriggerExit2D(Collider2D Other){
		if (Other.tag == "Player") {

				showGui = false;
				

		}
	}
	void OnGUI(){
		if (showGui == true) {
			

			GUI.Box (new Rect ( Screen.width - 1200,Screen.height -200  , Screen.width / 2, Screen.height / 3), "rekt message!", customGuiStyle);
			GUI.Box (new Rect (Screen.width - 1200,Screen.height -200  , Screen.width / 2, Screen.height / 3),oldmanHead);
		}
	}

}
