using UnityEngine;
using System.Collections;

public class SierraGirar : MonoBehaviour {
	public float velocidadrotacion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,0,120*Time.deltaTime*velocidadrotacion);
	}
}
