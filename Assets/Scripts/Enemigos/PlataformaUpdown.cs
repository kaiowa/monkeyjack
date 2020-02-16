﻿using UnityEngine;
using System.Collections;

// Tipos enumerados para definir las direcciones
public enum DireccionH { Izquierda, Derecha }
public enum DireccionV { Arriba, Abajo }

public class PlataformaUpdown : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public GameObject controller;
	private UI UI;
	private float xpos;


		// Es la velocidad a la que se moverá la plataforma en el eje horizontal.
		public float VelocidadH = 0.3F;
		
		// Indica el sentido horizontal al que comenzará a moverse la plataforma.
		public DireccionH SentidoH = DireccionH.Derecha;
		
		// Es la velocidad a la que se moverá la plataforma en el eje vertical.
		public float VelocidadV = 0.0F;
		
		// Indica el sentido vertical al que comenzará a moverse la plataforma.
		public DireccionV SentidoV = DireccionV.Arriba;
		
		// Es el la distancia que recorrerá la plataforma en modo ping-pong.
		// Para desactivar el modo ping-pong, establecer esta variable a -1.
		public float MaxRecorridoPingPong = 5.0F;
		
		// Variables privadas
		private Transform PlatformTransform;
		private float WalkedDistanceH = 0.0F;
		private float WalkedDistanceV = 0.0F;
		private float ReferencePingPongHPosition;
		private float ReferencePingPongVPosition;
		private Vector3 InitialPlatformPosition;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find("ControladorJuego");
		UI = controller.gameObject.GetComponent<UI>();

		PlatformTransform = transform;
		
		// Guardamos la posición inicial de la plataforma
		InitialPlatformPosition = PlatformTransform.position;
		
		// Inicializamos la posición de referencia para el cálculo de rebote horizontal (ping-pong)
		ReferencePingPongHPosition = PlatformTransform.position.x;
		
		// Inicializamos la posición de referencia para el cálculo de rebote vertical (ping-pong)
		ReferencePingPongVPosition = (PlatformTransform.position.y);

	}
	
	// Update is called once per frame
	void Update () {
	

		/*if (moveRight) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x,moveSpeed);
			
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x,-moveSpeed);
			
		}
		*/

			// Calculamos la distancia horizontal recorrida desde el último rebote
			WalkedDistanceH = Mathf.Abs(Mathf.Abs(PlatformTransform.position.x) - ReferencePingPongHPosition);
			
			// Calculamos la distancia vertical recorrida desde el último rebote
			WalkedDistanceV = Mathf.Abs(Mathf.Abs(PlatformTransform.position.y) - ReferencePingPongVPosition);
			
			if (MaxRecorridoPingPong != -1 && WalkedDistanceH >= MaxRecorridoPingPong)
			{
				// Si la función de Ping-Pong esta activada y se ha hecho el máximo recorrido en horizontal, la plataforma cambia de sentido
				if (SentidoH == DireccionH.Izquierda)
				{
					SentidoH = DireccionH.Derecha;
				}
				else
				{
					SentidoH = DireccionH.Izquierda;
				}
				
				// Actualizamos la posición horizontal de referencia para el cálculo de rebote horizontal (ping-pong)
				ReferencePingPongHPosition = Mathf.Abs(PlatformTransform.position.x);
			}
			
			if (MaxRecorridoPingPong != -1 && WalkedDistanceV >= MaxRecorridoPingPong)
			{
				// Si la función de Ping-Pong está activada y se ha hecho el máximo recorrido en vertical, la plataforma cambia de sentido
				if (SentidoV == DireccionV.Arriba)
				{
					SentidoV = DireccionV.Abajo;
				}
				else
				{
					SentidoV = DireccionV.Arriba;
				}
				
				// Actualizamos la posicion vertical de referencia para el calculo de rebote vertical (ping-pong)
				ReferencePingPongVPosition = Mathf.Abs(PlatformTransform.position.y);
			}
			
			// Configuramos el sentido del movimiento horizontal
			if (SentidoH == DireccionH.Izquierda)
			{
				VelocidadH = -Mathf.Abs(VelocidadH);
			}
			else
			{
				VelocidadH = Mathf.Abs(VelocidadH);
			}
			
			// Configuramos el sentido del movimiento vertical
			if (SentidoV == DireccionV.Abajo)
			{
				VelocidadV = -Mathf.Abs(VelocidadV);
			}
			else
			{
				VelocidadV = Mathf.Abs(VelocidadV);
			}
			
			// Movemos la plataforma
			PlatformTransform.Translate(new Vector3(VelocidadH, VelocidadV, 0) * Time.deltaTime);
		

		
	}

	void OnTriggerStay(Collider other)
	{
		// Incluímos como hijo de la plataforma a cualquier objeto que se pose sobre ella
		other.transform.parent = transform;
	}
	
	void OnTriggerExit(Collider other)
	{
		// Excluímos como hijo de la plataforma a cualquier objeto que se separe de ella
		other.transform.parent = null;
	}

}
