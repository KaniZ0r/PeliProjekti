using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ImageScript : MonoBehaviour {

	Image kuva;

	// Use this for initialization
	void Start () {
		kuva = GetComponent<Image> ();
	}
	
	public void SetImage(Sprite img) {
		kuva.sprite = img;
	}

}
