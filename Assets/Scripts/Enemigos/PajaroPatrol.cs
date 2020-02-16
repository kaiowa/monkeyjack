using UnityEngine;
using System.Collections;

public class PajaroPatrol : MonoBehaviour {
	public float moveSpeed;
	public bool moveRight;
	public GameObject controller;
	private UI UI;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("ControladorJuego");
		UI = controller.gameObject.GetComponent<UI>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (moveRight);
		if (moveRight) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed,GetComponent<Rigidbody2D> ().velocity.y);
			
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed,GetComponent<Rigidbody2D> ().velocity.y);
			
		}
		
	}
	void OnTriggerEnter2D (Collider2D col) 
	{
		
		if (col.tag == "bloqueador")
		{

			//float vol = Random.Range (volLowRange, volHighRange);
			//source.PlayOneShot(shootSound,vol);
			
			//UI.BombCheck();
			//UI.Score += _bombscore;
			moveRight = !moveRight;  
			
		}
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" )
		{
			//Debug.Log("Calling UI.PlayerDeath");
			UI.StartDeath(this.gameObject, other.gameObject);
			
			
		}
	}
}
