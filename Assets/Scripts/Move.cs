using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Stats stats;
	public float speed = 6.0F;
	public float jumpHeight = -200.0F;
	public bool facingLeft = true;
	public Transform groundCheck;
	bool grounded = false;
	float groundRadius= 0.2f;
	public LayerMask whatIsGround;
	private Vector3 direction = Vector3.zero;
	Animator anim;
	public Rigidbody2D rigidbody2D;
	void Start(){
		anim = GetComponent<Animator> ();
	}
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Grounded", grounded);
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);

		anim.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && facingLeft)
			Flip ();
		if (move < 0 && !facingLeft)
			Flip ();
	}
	void Update(){
		if (grounded && Input.GetKeyDown (KeyCode.UpArrow)) {
			rigidbody2D.AddForce (new Vector2 (0, jumpHeight));
			anim.SetBool ("Grounded", false);
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			BoxCollider2D girl = gameObject.GetComponent<BoxCollider2D>();
			PolygonCollider2D hitBox = GameObject.Find("Girl/HitBox").GetComponent<PolygonCollider2D>();
			BoxCollider2D ground = GameObject.Find("Ground").GetComponent <BoxCollider2D>();
			anim.SetBool ("Attacking", true);
			Physics2D.IgnoreCollision(girl, hitBox);
			Physics2D.IgnoreCollision(ground, hitBox);
		}
	}
	void Flip () {
		facingLeft = !facingLeft;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	void stopAttacking(){
		anim.SetBool ("Attacking", false);
	}
}
