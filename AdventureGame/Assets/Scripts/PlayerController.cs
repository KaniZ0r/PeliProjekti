using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rb2d;
	public float moveSpeed;

	public int currentXp;

	float face_Y;
	float face_X;

	public Transform sword;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("isAttacking", false);

		face_Y = Camera.main.ScreenToWorldPoint (Input.mousePosition).y - transform.position.y;
		face_X = Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x;


		Vector2 movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (movementVector != Vector2.zero) {
			anim.SetBool ("isWalking", true);
			anim.SetFloat("input_x", face_X);
			anim.SetFloat("input_y", face_Y);
		} else {
			anim.SetBool("isWalking", false);
			anim.SetFloat("input_x", face_X);
			anim.SetFloat("input_y", face_Y);
		}

		rb2d.MovePosition (rb2d.position + movementVector * Time.deltaTime * moveSpeed);

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			anim.SetFloat("input_x", face_X);
			anim.SetFloat("input_y", face_Y);
			anim.SetBool ("isAttacking", true);
		}

	}

	public void AddXP () {
		currentXp++;
	}
}
