using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
	
	public void SetText(string txt) {
		GetComponent<Text> ().text = txt;
	}
}
