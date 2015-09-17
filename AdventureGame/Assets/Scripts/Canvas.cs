using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Canvas : MonoBehaviour {

	Text txt;
	public int xp;

	void Start () {

		xp = FindObjectOfType<PlayerController> ().currentXp;
		txt = gameObject.GetComponent<Text> ();
		txt.text = "XP: " + xp;
	}

	void Update () {
		xp = FindObjectOfType<PlayerController> ().currentXp;
		txt.text = "XP: " + xp;
	}

}
