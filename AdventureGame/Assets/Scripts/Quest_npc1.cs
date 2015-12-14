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

	// Use this for initialization
	void Start () {
		QM = GameObject.FindWithTag ("QuestManager");
		textPhase = 0;
		player = GameObject.FindWithTag ("Player").transform;
	}
	
	void Update () {
		if (textbox.activeSelf) {
				switch (textPhase) {
				case 0:
				FindObjectOfType<ImageScript> ().SetImage (head_player);
					if (phase != 3){
						FindObjectOfType<TextScript> ().SetText("Hey stranger! Could you please help me? I've lost my dog Nami.\n\n\n\nPress Space to continue.");
					} else {
						FindObjectOfType<TextScript>().SetText ("Nami! Thank you so much for saving him!\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown(KeyCode.Space)){
						textPhase++;
					}
					break;
				case 1:
				FindObjectOfType<ImageScript> ().SetImage (head_player);
					if (phase != 3) {
						FindObjectOfType<TextScript>().SetText ("Well.. I can help you find your dog but I need help myself. Do you know those guards up there? I need to get past them.\n\n\nPress Space to continue.");
					} else {
						FindObjectOfType<TextScript>().SetText ("Okay, like i promised I will show you the way around the guards. Let's go!\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown(KeyCode.Space)){
						textPhase++;
					}
					break;
				case 2:
					if (phase != 3) {
						FindObjectOfType<ImageScript> ().SetImage (head_grill);
						FindObjectOfType<TextScript>().SetText ("I know how to get past those guards! If you find my dog Nami, I will show you the way.\n\n\n\nPress Space to continue.");
					} else {
					FindObjectOfType<TextScript>().SetText("Okay, like i promised I will show you the way around the guards. Let's go!\n\n\n\nPress Space to continue.");
					}
					if (Input.GetKeyDown(KeyCode.Space)){
						textPhase++;
					}
					break;
				case 3:
					if (phase != 3) {
						textbox.SetActive(false);
						FindObjectOfType<PlayerController>().UnFreeze();
						FindObjectOfType<QuestManager>().nextPhase();
						textPhase++;
					} else {
						StartCoroutine(Teleport());
					}
					break;
				default:
					FindObjectOfType<TextScript>().SetText ("Have you found Nami yet? I'm so worried.\n\n\n\n\n\nPress Space to continue.");
					if (Input.GetKeyDown(KeyCode.Space)){
						textbox.SetActive(false);
						FindObjectOfType<PlayerController>().UnFreeze();
					}
					break;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
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
