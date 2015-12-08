using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	//variables
	public float speed;
	public Controller2D player;

	public GameObject enemyDeath;

	public GameObject projectParticle;

	public int pointsForKill;



	// Use this for initialization
	void Start () {


		player = FindObjectOfType<Controller2D>();
		
		if (player.facingLeft) {
			speed = -speed;
			transform.localScale = new Vector3(-0.5f,-0.5f,1f);
			
		} else {
			speed = speed;
			transform.localScale = new Vector3(0.5f,0.5f,1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);



	}

	void OnTriggEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") {
			Instantiate(enemyDeath, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			//ScoreManager.AddPoints(pointsForKill);
		}

		Instantiate (projectParticle, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
