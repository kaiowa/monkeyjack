using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {


	public float angle;
	public float speed;
	public float changeAngleTime;
	public float magnitude;
	private float maxMagnitude = 5;
	public GameObject controller;
	private UI UI;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("ControladorJuego");
		UI = controller.gameObject.GetComponent<UI>();
		angle = Random.Range(0, 30);
		
		transform.Rotate(0, 0, 45);
		//rigidbody2D.AddForce(transform.up * speed);
		
		StartCoroutine("ChangeDirection");
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		magnitude = transform.GetComponent<Rigidbody2D>().velocity.sqrMagnitude;

	}
	
	void FixedUpdate()
	{
		
	}
	
	IEnumerator ChangeDirection()
	{
		yield return new WaitForSeconds (changeAngleTime);
		angle = (Random.Range(1, 4))*45;		
		transform.Rotate(0, 0, angle);
		//Debug.Log("Direction changed");
		
		//Vector2 vel = rigidbody2D.velocity;
		
		
		if ( magnitude < maxMagnitude)
		{
			GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
			//Debug.Log("Added speed...");
		}
		
		StartCoroutine("ChangeDirection");
		
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
