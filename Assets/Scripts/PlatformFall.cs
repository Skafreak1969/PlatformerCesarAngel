using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformFall : MonoBehaviour {

	public float fallDelay;
	private Rigidbody2D rb2d;
	GameObject SpawnManager;
	Scene escenaActual;
	GameObject [] array;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		SpawnManager = GameObject.Find ("SpawnManager");
		escenaActual = SceneManager.GetActiveScene ();
		if(escenaActual.name==("Level2")||escenaActual.name==("Level3")){
			fallDelay = 2;
		}
		if(escenaActual.name==("Level4")){
			fallDelay = 1;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Player")&&escenaActual.name!=("Level1")&&escenaActual.name!=("Level2")) {
			Invoke ("Fall", fallDelay);
		}
		if (other.gameObject.CompareTag ("Player")&&escenaActual.name==("Level2")) {
			int coinflip = Random.Range (0, 2);
			if (coinflip > 0) {
				Invoke ("Fall", fallDelay);
			}
		}
	}

	void FixedUpdate(){
		if (Mathf.Abs (rb2d.velocity.x) > 750) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x)*750, rb2d.velocity.y);
		}
	}

	void Fall(){
		rb2d.isKinematic = false;
		Invoke ("AgregarFuerza", 0.2f);
	}
	void AgregarFuerza(){
		rb2d.AddForce (new Vector2 (0f, -1000));
	}
}
