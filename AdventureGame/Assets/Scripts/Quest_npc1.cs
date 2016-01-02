using UnityEngine;
using System.Collections;

public class Quest_npc1 : MonoBehaviour {

	public Sprite head_grill;
	public Sprite head_player;
	public GameObject textbox;
	GameObject QM;
	public int phase;
	public int textPhase;
	public Transform warpTarget;
	Transform player;
	bool active;

	// Use this for initialization
	void Start () {
		QM = GameObject.FindWithTag ("QuestManager");
		textPhase = 0;
		player = GameObject.FindWithTag ("Player").transform;
		active = false;
	}
	
	void Update () {
		if (active) {
			if (textbox.activeSelf) {
				switch (textPhase) {
				case 0:
					if (phase != 3) {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_player);
						textbox.GetComponentInChildren<TextScript>().SetText ("Hey! Can you help me.........\n\n\n\n\nPress Space to continue.");
					} else {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_grill);
						textbox.GetComponentInChildren<TextScript>().SetText ("Nami! Thank you so much for saving him!\n\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						textPhase++;
					}
					break;
				case 1:

					if (phase != 3) {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_grill);
						textbox.GetComponentInChildren<TextScript>().SetText ("*crying*\nPlease help me..... my dog ran away. Could you retrieve it for me?\nI do not dare travel in these woods alone with all those fierce beasts lurking around.\nPress Space to continue.");
					} else {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_player);
						textbox.GetComponentInChildren<TextScript>().SetText ("Sure but do not forget our agreement.\n\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						textPhase++;
					}
					break;
				case 2:
					if (phase != 3) {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_player);
						textbox.GetComponentInChildren<TextScript>().SetText ("Sure, but you owe me a favour in return!\n\n\n\n\nPress Space to continue.");
					} else {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_grill);
						textbox.GetComponentInChildren<TextScript>().SetText ("Yes ofcourse!\nBurger Börder Spurdolum\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						textPhase++;
					}
					break;
				case 3:
					if (phase != 3) {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_grill);
						textbox.GetComponentInChildren<TextScript>().SetText ("I could show you a route past northern guards!\n\n\n\n\nPress Space to continue.");
					} else {
						StartCoroutine (Teleport ());
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						textPhase++;
					}
					break;
				case 4:
					if (phase != 3) {
						textbox.GetComponentInChildren<ImageScript>().SetImage(head_player);
						textbox.GetComponentInChildren<TextScript>().SetText("Deal!\n\n\n\n\nPress Space to continue.");
					} else {
						textbox.GetComponentInChildren<ImageScript>().SetImage (head_grill);
						textbox.GetComponentInChildren<TextScript>().SetText ("YOU SHOULDN'T BE HERE!\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown (KeyCode.Space)) {
						QM.GetComponent<QuestManager>().nextPhase();
						textbox.SetActive(false);
						textPhase++;
						FindObjectOfType<PlayerController>().UnFreeze();
					}
					break;
				default:
					textbox.GetComponentInChildren<ImageScript>().SetImage (head_grill);
					textbox.GetComponentInChildren<TextScript>().SetText ("Have you found Nami yet? I'm so worried.\n\n\n\n\n\nPress Space to continue.");
					if (Input.GetKeyDown (KeyCode.Space)) {
						textbox.SetActive (false);
						FindObjectOfType<PlayerController> ().UnFreeze ();
					}
					break;
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			active = true;
			textbox.SetActive(true);
			FindObjectOfType<PlayerController> ().Freeze ();
			phase = QM.GetComponent<QuestManager> ().phase;
		}
	}

	public void resetText(){
		textPhase = 0;
	}

	IEnumerator Teleport() {
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
		textbox.SetActive (false);
		yield return StartCoroutine (sf.FadeToBlack ());

		player.transform.position = warpTarget.transform.position;
		yield return StartCoroutine (sf.FadeToClear ());
		FindObjectOfType<PlayerController> ().UnFreeze ();
	}
}
