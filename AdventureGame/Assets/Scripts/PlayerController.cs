using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator anim;
	public Rigidbody2D rb2d;
	public float moveSpeed;

	public int currentXp;

	float face_Y;
	float face_X;

	bool stopper;

	public Transform sword;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		stopper = false;
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("isAttacking", false);

			Vector2 movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));


		if (!stopper) {
			if (movementVector != Vector2.zero) {
				face_Y = Input.GetAxisRaw("Vertical");
				face_X = Input.GetAxisRaw ("Horizontal");
				anim.SetBool ("isWalking", true);
				anim.SetFloat("X", face_X);
				anim.SetFloat("Y", face_Y);
			} else {
				anim.SetBool("isWalking", false);
				anim.SetFloat("X", face_X);
				anim.SetFloat("Y", face_Y);
			}

			rb2d.MovePosition (rb2d.position + movementVector * Time.deltaTime * moveSpeed);

			if (Input.GetKeyDown (KeyCode.Space)) {
				anim.SetFloat("X", face_X);
				anim.SetFloat("Y", face_Y);
				anim.SetBool ("isAttacking", true);
			}
		}

	}

	public void AddXP () {
		currentXp++;
	}

	public void Freeze () {
		anim.SetBool ("isWalking", false);
		stopper = true;
	}

	public void UnFreeze () {
		stopper = false;
	}
}
