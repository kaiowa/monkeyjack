using UnityEngine;
using System.Collections;

public class Botones : MonoBehaviour {

	void start(){
	
	}
	public void jugar(){
		Application.LoadLevel("stage1");
	}
	 void opciones(){
		Application.LoadLevel("scene1");
	}


}
