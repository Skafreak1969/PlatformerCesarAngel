using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	GameObject GUIController;
	AudioSource source;

	// Use this for initialization
	void Start () {
		GUIController = GameObject.Find ("GUIController");
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestruirMoneda(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			GUIController.GetComponent<GUIController> ().sumarScore ();
			source.Play ();
			Invoke ("DestruirMoneda", 0.2f);
		}
	}
}
