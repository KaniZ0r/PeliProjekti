using UnityEngine;
using System.Collections;

public class QuestManager : MonoBehaviour {

	public GameObject BossManager;
	public GameObject Nami;
	public int phase;

	// Use this for initialization
	void Start () {
		phase = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (phase) {
		case 0:
			break;
		case 1:
			BossManager.gameObject.SetActive (true);
			break;
		case 2:
			Nami.gameObject.SetActive (true);
			phase++;
			break;
		case 3:
			if (BossManager){
				BossManager.gameObject.SetActive (false);
			}
			break;
		}
	}
	public void nextPhase(){
		phase++;
	}
}
