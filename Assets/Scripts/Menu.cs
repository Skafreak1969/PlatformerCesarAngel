using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		if (SceneManager.GetActiveScene ().name =="Menu") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
		if (SceneManager.GetActiveScene ().name=="Menu 1") {
			SceneManager.LoadScene (0);
		}
	}
}
