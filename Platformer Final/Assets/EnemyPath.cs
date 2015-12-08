using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;
	//Edge Check Variables
	private bool notAtEdge;
	public Transform edgeCheck;
	public LayerMask whatIsGround;

	bool test;

	// Use this for initialization
	void Start () {
	


	}


	void FixedUpdate(){
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsGround);
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

	}

	
	// Update is called once per frame
	void Update () {


		
		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}
		
		if (moveRight) {
			transform.localScale = new Vector3 (2f, 2f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} 
		else {
			transform.localScale = new Vector3 (-2f, 2f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}


	}
}
