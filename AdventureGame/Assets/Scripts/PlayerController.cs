using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb2d;
	public float moveSpeed;
	public int currentHP;
	public int maxHP;

	public int currentXp;

	float face_Y;
	float face_X;

	float xK;
	float yK;

	bool stopper;

	public float knockdur;
	float timer;
	bool knock;
	public int knockSpeed;

	public bool dash;
	public int dashSpeed;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		stopper = false;
		currentHP = maxHP;
		knock = false;
		dash = false;
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("isAttacking", false);

		Vector2 movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (currentHP <= 0) {
			FindObjectOfType<Enemy>().target = null;
			Freeze();
			anim.SetBool("die", true);
			Destroy(gameObject, 2);
		}

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
			if (Input.GetKeyDown (KeyCode.Q)) {
				dash = true;
			}

			if (!knock) {
				if (dash) {
					if (knockdur > timer) {
						rb2d.MovePosition (rb2d.position + movementVector * Time.deltaTime * dashSpeed);
						timer += Time.deltaTime;
					} else {
						timer = 0;
						dash = false;
					}
				} else {
					rb2d.MovePosition (rb2d.position + movementVector * Time.deltaTime * moveSpeed);
				}
			} else {
				if (knockdur > timer) {
					Vector2 movementVector2 = new Vector2 ((transform.position.x - xK),(transform.position.y - yK));
					rb2d.MovePosition (rb2d.position + movementVector2 * Time.deltaTime * knockSpeed);
					timer += Time.deltaTime;
				} else {
					timer = 0;
					knock = false;
				}
			}

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

	public void takeDamage () {
		currentHP--;
	}

	public void knockBack (float x, float y) {
		knock = true;
		xK = x;
		yK = y;
	}
}
