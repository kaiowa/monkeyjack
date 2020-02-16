using UnityEngine;
using System.Collections;

public class EnemigoObjeto : MonoBehaviour {
	public GameObject controller;
	private UI UI;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("ControladorJuego");
		UI = controller.gameObject.GetComponent<UI>();

	}
	
	// Update is called once per frame
	void Update () {
	
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
