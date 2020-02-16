using UnityEngine;
using System.Collections;
using CnControls;

public class PlayerScript : MonoBehaviour {
	public float WalkSpeed;
	public float JumpImpulse;
	public float minijump;
	public Transform groundCheckPoint;
	public LayerMask whatIsGround;

	public bool Cayendo;

	private Rigidbody2D body;
	private Vector2 movement;

	private float horInput;
	public bool jumpInput;
	public bool superjumpInput;

	private bool iAmIntheGround;
	private Animator anim;
	private bool facingRight;

	public AudioClip jumpSound;
	public AudioClip miniJumpSound;
	

	private Vector2 zero = new Vector2(0,0);
	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Rigidbody2D>();
		this.movement = new Vector2 ();
		this.iAmIntheGround = false;

		this.anim = this.GetComponent<Animator> ();
		this.facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {


		this.horInput =Input.GetAxis ("Horizontal");
		this.jumpInput=Input.GetKey (KeyCode.Space);
		//this.jumpInput = Input.GetKey (KeyCode.Space);
		this.superjumpInput = Input.GetKey (KeyCode.UpArrow);

		if ((this.horInput < 0) && (this.facingRight)) {
			this.Flip();
			this.facingRight=false;
		}else if  ((this.horInput > 0) && (!this.facingRight)) {
			this.Flip();
			this.facingRight=true;
		}

		if (Physics2D.OverlapCircle (groundCheckPoint.position, 0.02f, this.whatIsGround)) {
			this.iAmIntheGround = true;
		} else {
			this.iAmIntheGround=false;
		}
		this.anim.SetFloat("HorSpeed", Mathf.Abs(this.body.velocity.x));
		this.anim.SetFloat("VertSpeed", Mathf.Abs(this.body.velocity.y));
	}
	void FixedUpdate(){
		this.movement = this.body.velocity;

		this.movement.x = horInput * WalkSpeed;
		if (this.jumpInput && this.iAmIntheGround) {
			GetComponent<AudioSource>().PlayOneShot(jumpSound, 0.5f);
			if(this.superjumpInput)
			{
				//supersalto
				this.movement.y=JumpImpulse*1.7f;
			}
			else
			{

				this.movement.y=JumpImpulse;
			}
		}
		if (this.jumpInput && !this.iAmIntheGround) {
			Debug.Log ("minijump");

			GetComponent<Rigidbody2D>().velocity = zero;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, minijump));
			GetComponent<AudioSource>().PlayOneShot(miniJumpSound, 0.5f);
			this.anim.SetBool("Cayendo",true);
			//GetComponent<AudioSource>().PlayOneShot(miniJumpSound, 0.5f);

		}
		if (!this.iAmIntheGround) {
			if(this.movement.y<-4)
			{
				this.movement.y=-4;
			}
		}

		this.body.velocity = this.movement;
	}
	void Flip()
	{
		Vector3 scale = this.transform.localScale;
		scale.x *= (-1);
		this.transform.localScale = scale;
	}


}
