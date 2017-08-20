using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {
	static int vidas=3;
	static int score = 0;
	public Text GUIVidas;
	public Text GUIScore;

	public int GetVidas (){
		return vidas;
	}

	public void restarVidas(){
		vidas--;
	}

	public void sumarScore (){
		score += 100;
	}

	public void reiniciarVidas(){
		vidas=0;
	}

	public void reiniciarScore (){
		score = 0;
	}

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GUIVidas.text = vidas.ToString();
		GUIScore.text = score.ToString ();

		if(vidas==0){
			vidas = 3;
			score = 0;
			SceneManager.LoadScene ("Menu 1");
		}
	}
}
