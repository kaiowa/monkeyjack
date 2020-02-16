using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {


	public static UI ui;

	private float _score;
	private int _lives;
	private int round;

	public AudioClip completedSound;
	public AudioClip bombPickupSound;
	public AudioClip playerDeathSound;

	public TextMesh vidastext;
	public TextMesh puntostext;

	private PlayerSpawner playerSpawn;

	public float Score {
		get {
			return _score;
		}
		set {
			_score = value;
		}
	}
	
	public int Lives {
		get {
			return _lives;
		}
		set {
			_lives = value;
		}
	}
	
	void Awake ()
	{

			if (ui == null) {	
				ui = this;
				DontDestroyOnLoad (transform.gameObject);
			}else if (ui!=null)
			{
				Destroy(gameObject);	
			}

	}

	// Use this for initialization
	void Start () {
		Lives = 3;
		vidastext.text = "x"+Lives.ToString ();
		puntostext.text = "0";
		playerSpawn = GameObject.Find ("PlayerSpawner").GetComponent<PlayerSpawner> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI ()
	{

		puntostext.text = Score.ToString();
		vidastext.text = "x"+Lives.ToString ();



	}
	public void StartDeath (GameObject player, GameObject other)
	{
		StartCoroutine (PlayerDeath (player, other));
	}
	
	IEnumerator PlayerDeath (GameObject player, GameObject other)
	{
		if (Lives > 0) {
			//Debug.Log("PlayerDeath Co-routine");
			//Destroy (player);

			Destroy (other); // other es el player
			GetComponent<AudioSource>().PlayOneShot (playerDeathSound);
			yield return new WaitForSeconds (2);
			Lives -= 1;
			yield return new WaitForSeconds (1);
			playerSpawn.Spawn();
		

		} else {
			Debug.Log ("menuuuu");
			yield return new WaitForSeconds (2);
			Application.LoadLevel (0);
		}
		
	}
	
	public void BombCheck ()
	{
		GameObject[] bombs = GameObject.FindGameObjectsWithTag ("coin") as GameObject[];
		int numberOfBombsLeft = bombs.Length - 1;

		GetComponent<AudioSource>().PlayOneShot (bombPickupSound, 0.3f);


		if (numberOfBombsLeft == 0) {
			
			if (Application.loadedLevel < 3) {
				GetComponent<AudioSource>().PlayOneShot (completedSound);
				Application.LoadLevel (Application.loadedLevel + 1);
			} else {
				//GetComponent<AudioSource>().PlayOneShot(endedSound);
				Application.LoadLevel ("Menu");
			}
		}
	}
	public void dibujarVidas()
	{
		

	}


}
