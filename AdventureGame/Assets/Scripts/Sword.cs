using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	public float kulmakerroin;
	public float radiaanit;
	public float asteet;
	
	Rigidbody2D rb2d;
	Vector3 velocity1;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		kulmakerroin = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y) / (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
		radiaanit = Mathf.Atan (kulmakerroin);
		asteet = Mathf.Rad2Deg * radiaanit - 90;
		
		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x) {
			transform.eulerAngles = new Vector3 (0, 0, asteet);
		} else {
			transform.eulerAngles = new Vector3 (0, 0, asteet + 180);
		}

		//velocity1 = transform.rotation * Vector3.up * 20f;
		//rb2d.AddForce(velocity1);
	}
	
	// Update is called once per frame
	void Update () {

		kulmakerroin = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y) / (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
		radiaanit = Mathf.Atan (kulmakerroin);
		asteet = Mathf.Rad2Deg * radiaanit - 90;
		
		if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x > transform.position.x) {
			transform.eulerAngles = new Vector3 (0, 0, asteet);
		} else {
			transform.eulerAngles = new Vector3 (0, 0, asteet + 180);
		}

		//Destroy (gameObject, 0.2f);

	}
}
