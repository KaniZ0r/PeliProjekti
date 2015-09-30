using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {


	Text text;

	void Start () {
		text = GetComponent<Text> ();
	}

	public void SetText(string txt) {
		text.text = txt;
	}
}
