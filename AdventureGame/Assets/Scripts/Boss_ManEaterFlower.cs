using UnityEngine;
using System.Collections;

public class Boss_ManEaterFlower : MonoBehaviour {

	Transform target;
	public GameObject projectile;
	Animator anim;
	float x;
	float y;
	public int health;
	bool start;
	
		

	void Start () {
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag ("Player").transform;
		start = false;
	}
	
	// Update is called once per frame
	void Update () {
		x = target.transform.position.x - transform.position.x;
		y = target.transform.position.y - transform.position.y;
		
		anim.SetFloat ("X", x);
		anim.SetFloat ("Y", y);

		if (health <= 0) {
			Destroy(gameObject);
		}

		if (start) {
			StartCoroutine (shootProjectile (3f));
			start = false;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Weapon") {
			FindObjectOfType<PlayerController>().knockBack(transform.position.x, transform.position.y);
			health--;
		}
	}

	public void setStart (){
		start = true;
	}

	IEnumerator shootProjectile (float seconds){
		while (true) {
			yield return new WaitForSeconds (seconds);
			Instantiate (projectile, this.transform.position, target.transform.rotation);
			yield return new WaitForSeconds (0.5f);
			Instantiate (projectile, this.transform.position, target.transform.rotation);
			yield return new WaitForSeconds (0.5f);
			Instantiate (projectile, this.transform.position, target.transform.rotation);
		}
	}
}
