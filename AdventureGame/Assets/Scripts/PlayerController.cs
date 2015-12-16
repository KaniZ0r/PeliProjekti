using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb2d;
	public float moveSpeed;
	public int currentHP;
	public int maxHP;
	AudioSource dashSound;
	AudioSource hurt;
	AudioSource sword;

	public Scrollbar DashIndicator;
	float fullDashBar;
	float dashBar;

	public int currentXp;
	public bool immune;
	float immuneDur;

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
	bool dashSoundq;
	public int dashSpeed;
	float dashTimer;
	Vector2 movementVector;
	bool takeD;

	public int coins;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		stopper = false;
		currentHP = maxHP;
		knock = false;
		dash = false;
		dashTimer = 2;
		takeD = false;
		immune = false;
		immuneDur = 0;
		var sources = GetComponents<AudioSource> ();
		dashSound = sources [0];
		hurt = sources [1];
		sword = sources [2];
		fullDashBar = 1;
		dashBar = fullDashBar;
		coins = 0;
		dashSoundq = true;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("die", false);
		anim.SetBool ("isAttacking", false);
		movementVector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		DashIndicator.size = dashBar / fullDashBar;

		if (currentHP <= 0) {
			anim.SetBool ("die", true);
		} else {
			if (immune) {
				if (immuneDur < 1) {
					immuneDur += Time.deltaTime;
				} else {
					immune = false;
				}
			} else {
				immuneDur = 0;
			}
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
			if (dashTimer < 1) {
				dashBar += Time.deltaTime;
				dashTimer += Time.deltaTime;
			}
			if (dashTimer >= 1){
				if (Input.GetKeyDown (KeyCode.Q)) {
					dash = true;
					dashSoundq = true;
				}
			}

			if (!knock) {
				if (dash) {
					if (dashSoundq){
						dashSound.Play();
						dashSoundq = false;
					}
					dashBar = 0;
					if (knockdur > timer) {
						rb2d.MovePosition (rb2d.position + movementVector * Time.deltaTime * dashSpeed);
						timer += Time.deltaTime;

					} else {
						timer = 0;
						dashTimer = 0;
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
					if (takeD){
						hurt.Play();
						anim.SetBool ("hurt", true);
						immune = true;
					}
				} else {
					timer = 0;
					knock = false;
					if (takeD) {
						anim.SetBool ("hurt", false);
						takeD = false;
					}
				}
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				anim.SetFloat("X", face_X);
				anim.SetFloat("Y", face_Y);
				anim.SetBool ("isAttacking", true);
				sword.Play ();
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
		if (!immune) {
			takeD = true;
			currentHP--;
		}
	}

	public void knockBack (float x, float y) {
		if (!immune) {
			knock = true;
			xK = x;
			yK = y;
		}
	}

	public void addCoins (){
		coins++;
	}
}
