using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {
	GameObject GUIController;
	private bool restar;
	// Use this for initialization
	void Start () {
		GUIController= GameObject.Find ("GUIController");
		restar = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			if (restar) {
				GUIController.GetComponent<GUIController> ().restarVidas ();
				restar = false;
			}
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
		if (other.gameObject.CompareTag ("ground")) {
			Destroy (other.gameObject);
		}
	}
}
