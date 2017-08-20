using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	GameObject [] array;

	bool once;
	GameObject GUIController;

	// Use this for initialization
	void Awake () {
		
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
		once = true;
		GUIController = GameObject.Find ("GUIController");
	}

	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if(once){
			array = GameObject.FindGameObjectsWithTag ("ground");
			once = false;
		}
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
		}
	}

	void FixedUpdate(){
		
		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (h));
		if(h * rb2d.velocity.x<maxSpeed){
			rb2d.AddForce (Vector2.right * h * moveForce);
		}
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2 (Mathf.Sign (rb2d.velocity.x)*maxSpeed, rb2d.velocity.y);
		}
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}
		if (jump) {
			anim.SetTrigger ("Jump");
			rb2d.AddForce (new Vector2 (0f, jumpForce));
			jump = false;
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.transform.position.x >= array [array.Length - 1].transform.position.x) {
			PasarEscena ();		
		}
	}

	void PasarEscena(){
		if(SceneManager.GetActiveScene().buildIndex==4){
			GUIController.GetComponent<GUIController> ().reiniciarScore ();
			GUIController.GetComponent<GUIController> ().reiniciarVidas ();
		}
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
}
