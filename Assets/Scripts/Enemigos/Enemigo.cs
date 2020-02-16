using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {
	public float velocidad;
	public GameObject enemigo;
	private bool facingRight;
	private float horInput;
	// Use this for initialization
	void Start () {
		facingRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.horInput = Input.GetAxis ("Horizontal");
		transform.position = transform.position + new Vector3 (velocidad, 0, 0) * Time.deltaTime;

	}
	void FixedUpdate(){


	}
	void OnTriggerEnter2D (Collider2D col) 
	{
		
		if (col.tag == "bloqueador")
		{
			
			//float vol = Random.Range (volLowRange, volHighRange);
			//source.PlayOneShot(shootSound,vol);
			
			//UI.BombCheck();
			//UI.Score += _bombscore;
			Flip();   
			
		}
	}
	void Flip()
	{
		Vector3 scale = this.transform.localScale;
		scale.x *= (-1);
		this.transform.localScale = scale;
	}
}
