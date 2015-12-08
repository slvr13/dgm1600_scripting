using UnityEngine;
using System.Collections;

public class Controller2D : MonoBehaviour {
	
	// Player Movement
	public float moveSpeed;
	public float jumpHeight;
	public bool facingLeft = false;
	private bool grounded=false;

	// No Stick
	private float moveVelocity;
	
	//Ground Check
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	
	// Double Jump Variables
	private bool doubleJumped=true;
	
	
	//Player Animation
	//private Animator anim; 
	
	void Start(){
		//anim = GetComponent<Animator>();
	}
	
	void FixedUpdate(){
	
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

	}
	
	void Update() {

		// This code makes the character jump
		if(Input.GetKeyDown (KeyCode.Space)&& grounded){
			Jump();
		}
		
		// Double jump code
		if(grounded)
			doubleJumped = false;
		
		if(Input.GetKeyDown (KeyCode.Space)&& !doubleJumped && !grounded){
			Jump();
			doubleJumped = true;
		}

		//No Stick
		moveVelocity = 0f;

		

		// Move Right
		if(Input.GetKey(KeyCode.D)){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
			facingLeft=false;
		}
		
		// Move Left
		if(Input.GetKey(KeyCode.A) ){
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y); 
			moveVelocity = -moveSpeed;
			facingLeft=true;
		}
		
		// No Stick Player
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		
		//Player walk animation
		//anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		//Player flip
		if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(-1f,1f,1f);
		
		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(1f,1f,1f);



//		// Jump
//		if(Input.GetKeyDown (KeyCode.Space)&& grounded){
//			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
//		}
//		
//		// Double Jump
//		if (grounded) {
//			doubleJumped = false;
//		}
//		
//		//Player Jump Animation
//		//anim.SetBool("Grounded",grounded);
//		
//		if(Input.GetKeyDown (KeyCode.Space)&& !doubleJumped && !grounded  ){
//			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
//			doubleJumped = true;
//		}


		
	}

	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
	
}