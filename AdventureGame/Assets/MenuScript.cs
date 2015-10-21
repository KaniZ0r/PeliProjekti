using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public void StartLevel(){
		Application.LoadLevel ("DevZone 1");
	}

	public void Exit() {
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
