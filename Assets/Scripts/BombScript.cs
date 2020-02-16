using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	


	public AudioClip jumpSound;
	private bool sonido;


	private float bombscore = 100;
	private bool destruir;

	public GameObject controller;
	private UI UI;
	// Use this for initialization
	void Start () {

		controller = GameObject.Find("ControladorJuego");
		UI = controller.gameObject.GetComponent<UI>();

	}
	
	// Update is called once per frame
	void Update () {
			//Debug.Log (MIUI.Score);
			//UI.Score += this.bombscore;

		
			//UI.Score += _bombscore;
			//
		

	}
	void FixedUpdate(){

	}
	void OnTriggerEnter2D (Collider2D col) 
	{
	
		// el jugador ha pillado una moneda
		if (col.tag == "Player")
		{

			UI.Score += this.bombscore;
			UI.BombCheck();
			//this.destruir=true;
			Destroy (gameObject); 

		}
	}


}
