using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject startGame;
	public GameObject exitGame;
	public GameObject options;
	public Sprite img1;
	public Sprite img2;
	int currentObject;

	// Use this for initialization
	void Start () {
		currentObject = 1;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentObject) {
		case 1:
			startGame.GetComponent<ImageScript>().SetImage(img2);
			exitGame.GetComponent<ImageScript>().SetImage(img1);
			options.GetComponent<ImageScript>().SetImage(img1);
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				currentObject = 2;
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				currentObject = 3;
			} else if (Input.GetKeyDown (KeyCode.Return)){
				Application.LoadLevel ("Level1");
			}
			break;
		case 2:
			startGame.GetComponent<ImageScript>().SetImage(img1);
			exitGame.GetComponent<ImageScript>().SetImage(img2);
			options.GetComponent<ImageScript>().SetImage(img1);
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				currentObject = 3;
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				currentObject = 1;
			}
			break;
		case 3:
			startGame.GetComponent<ImageScript>().SetImage(img1);
			exitGame.GetComponent<ImageScript>().SetImage(img1);
			options.GetComponent<ImageScript>().SetImage(img2);
			if (Input.GetKeyDown(KeyCode.UpArrow)){
				currentObject = 1;
			} else if (Input.GetKeyDown(KeyCode.DownArrow)){
				currentObject = 2;
			}
			break;
		}


	}
}
